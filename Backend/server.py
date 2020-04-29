from flask import Flask, request
import threading
import html_generator
import shutil
import cnn
import os

app = Flask(__name__)
args = {'data': str, 'target': str, 'rate': float}
threads = dict()


def check_type(type_lr, type_data, input_shape, output_shape):
    """
    Проверка правильности соотношения типов
    :param type_lr: тип машинного обучения
    :param type_data: тип данных
    :param input_shape: размерность входных данных
    :param output_shape: размерность выходных данных
    """
    if type_data == cnn.IMAGE and len(input_shape) != 2:
        raise RuntimeError
    if type_data == cnn.MATRIX and len(input_shape) != 1:
        raise RuntimeError
    if type_lr == cnn.REGRESSION and output_shape != 1:
        raise RuntimeError


def get_args():
    """
    Получение параметров из запроса
    """
    data = cnn.file.json_from_text(request.args.get('network', type=str))
    args_values = {arg: request.args.get(arg, type=args[arg]) for arg in args}
    args_values['data_type'] = cnn.file.get_data_type(data)
    args_values['input_shape'] = cnn.file.get_input_shape(data)
    args_values['type_sl'] = cnn.file.get_type(data)
    epochs = request.args.get('epochs', type=int)
    batch_size = request.args.get('batch_size', type=int)
    batch_size = None if batch_size == 0 else batch_size
    return data, args_values, epochs, batch_size


def get_network(id_user, name, layers, params):
    """
    Получение и компиляция нейронной сети
    :param name: название нейронной сети
    :param id_user: имя пользователя
    :param layers: слои
    :param params: параметры компиляции
    """
    return cnn.NeuralNetwork(id_user, name, layers).compile(params)


@app.route("/<id_user>/<name>/compile", methods=['GET'])
def compile_network(id_user, name):
    """
    Запрос на компиляцию нейронной сети
    :param id_user: имя пользователя
    :param name: название нейронной сети
    """
    shutil.rmtree(f'logs/{id_user}/{name}', ignore_errors=True)
    data = cnn.file.json_from_text(request.args.get('network', type=str))
    check_type(
        cnn.file.get_type(data), cnn.file.get_data_type(data),
        cnn.file.get_input_shape(data), cnn.file.get_output_shape(data)
    )
    network = get_network(id_user, name, cnn.file.get_network_layers(data), cnn.file.get_network_params(data))
    return network.get_information()


@app.route("/open", methods=['GET'])
def open_csv():
    """
    Запрос на открытие данных
    """
    return html_generator.data_to_html(request.args.get('data', type=str))


@app.route("/<id_user>/<name>/start_train", methods=['GET'])
def start_train_network(id_user, name):
    """
    Запрос на тренировку нейронной сети
    :param id_user: имя пользователя
    :param name: название нейронной сети
    """
    data, args_values, epochs, batch_size = get_args()
    dataset = cnn.dataset.get_data(**args_values)
    layers, params = cnn.file.get_network_layers(data), cnn.file.get_network_params(data)
    network = get_network(id_user, name, layers, params)
    threads[(id_user, name)] = threading.Thread(target=network.fit, args=[dataset, epochs, batch_size])
    threads[(id_user, name)].start()
    cnn.python_generator.save_network_to_code(id_user, name, args_values, layers, params, epochs, batch_size)
    return os.getcwd() + f'\\logs\\{id_user}\\{name}\\program.py'


@app.route("/<id_user>/<name>/get_loss", methods=['GET'])
def get_loss(id_user, name):
    """
    Запрос на получение графика с loss метрикой
    :param id_user: имя пользователя
    :param name: название нейронной сети
    """
    path = f'logs/{id_user}/{name}/stop.txt'
    if cnn.file.read_from_file(path) == 'yes': return os.getcwd() + f'\\logs\\{id_user}\\{name}\\weights.zip'
    if not os.path.isdir(f'logs/{id_user}/{name}/result'): return ''
    return html_generator.logs_to_png(id_user, name, 'loss')


@app.route("/<id_user>/<name>/get_accuracy", methods=['GET'])
def get_accuracy(id_user, name):
    """
    Запрос на получение графика с accuracy метрикой
    :param id_user: имя пользователя
    :param name: название нейронной сети
    """
    path = f'logs/{id_user}/{name}/stop.txt'
    if cnn.file.read_from_file(path) == 'yes': return os.getcwd() + f'\\logs\\{id_user}\\{name}\\weights.zip'
    if not os.path.isdir(f'logs/{id_user}/{name}/result'): return ''
    return html_generator.logs_to_png(id_user, name, 'accuracy')


@app.route("/<id_user>/<name>/close_train", methods=['GET'])
def close_train(id_user, name):
    """
    Запрос на окончание обучения нейронной сети
    :param id_user: имя пользователя
    :param name: название нейронной сети
    """
    threads[(id_user, name)] = None
    shutil.rmtree(f'logs/{id_user}/{name}', ignore_errors=True)
    return "done!"


if __name__ == '__main__':
    app.run()
