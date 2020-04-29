def generate_data(data, target, rate, data_type, type_sl, input_shape):
    """
    Генерация кода для данных
    :param data: ссылка на данные
    :param target: значение признака, который необходимо предсказывать
    :param rate: доля тренировочных данных в датасете
    :param data_type: тип данных
    :param type_sl: тип машинного обучения
    :param input_shape: размер входных данных
    """
    data = data.replace('\\', "\\\\")
    return f'data = get_data("{data}", "{target}", {rate}, "{data_type}", "{type_sl}", {input_shape})'


def generate_train(epochs, batch_size):
    """
    Генерация кода для тренировки
    :param epochs: количество эпох
    :param batch_size: размер батча
    """
    return f'model.fit(data[0], data[2], epochs={epochs}, batch_size={batch_size}, validation_data=(data[1], data[3]),)'
