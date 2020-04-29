from cnn.params import change_params


MODEL_COMPILE = 'model.compile'


def generate_compile(params):
    """
    Генерация кода компиляции
    :param params: параметры компиляции
    """
    result = list()
    params = change_params(params)
    for name in params:
        if type(params[name]) == str:
            result.append(f'{name}="{params[name]}"')
        else:
            result.append(f'{name}={params[name]}')
    return f'{MODEL_COMPILE}({", ".join(result)})'
