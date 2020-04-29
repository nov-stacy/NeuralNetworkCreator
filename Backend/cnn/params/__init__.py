def change_layer_params(params):
    """
    Изменение параметров слоя (настройка корректности)
    :param params: параметры
    """
    if 'input_shape' in params:
        params['input_shape'].append(1)
    for key in ['kernel', 'pool']:
        if f'{key}_size_1' in params:
            params[f'{key}_size'] = (params[f'{key}_size_1'], params[f'{key}_size_2'])
            del params[f'{key}_size_1'], params[f'{key}_size_2']
    return params


def change_params(params):
    """
    Изменение параметров нейронной сети (настройка корректности)
    :param params: параметры
    """
    if 'metrics' in params:
        params['metrics'] = [params['metrics']]
    return params
