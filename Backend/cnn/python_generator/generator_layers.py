from cnn.params import change_layer_params

LAYER_NAMES = {
    'Dense': 'keras.layers.Dense',
    'Flatten': 'keras.layers.Flatten',
    'Dropout': 'keras.layers.Dropout',
    'MaxPooling1D': 'keras.layers.MaxPooling1D',
    'MaxPooling2D': 'keras.layers.MaxPooling2D',
    'Conv1D': 'keras.layers.Conv1D',
    'Conv2D': 'keras.layers.Conv2D'
}

MODEL_ADD = 'model.add'


def generate_layers(layers):
    """
    Генерация кода слоев
    :param layers: слои
    """
    result = list()
    for layer in layers:
        params = change_layer_params(layer["params"])
        result_params = list()
        for name in params:
            if type(params[name]) == str:
                result_params.append(f'{name}="{params[name]}"')
            else:
                result_params.append(f'{name}={params[name]}')
        result.append(f'{MODEL_ADD}({LAYER_NAMES[layer["type"]]}({", ".join(result_params)}))')
    return "\n    ".join(result)
