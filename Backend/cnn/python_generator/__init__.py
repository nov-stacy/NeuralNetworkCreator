def save_network_to_code(id_user, name, args_values, layers, params, epochs, batch_size):
    """
    Сохранение обучения нейронной сети в код
    :param id_user: имя пользователя
    :param name: название нейронной сети
    :param args_values: аргументы для данных
    :param layers: слои
    :param params: параметры компиляции
    :param epochs: количество эпох
    :param batch_size: размерность батча
    :return:
    """
    from cnn.python_generator.generator_main import generate_main
    with open(f'logs/{id_user}/{name}/program.py', 'w', encoding='utf8') as _file:
        print(generate_main(args_values, layers, params, epochs, batch_size), file=_file)
