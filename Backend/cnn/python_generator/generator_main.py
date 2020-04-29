from cnn.python_generator.generator_layers import generate_layers
from cnn.python_generator.generator_compile import generate_compile
from cnn.python_generator.generator_train import generate_data, generate_train
from cnn.python_generator.generator_static import *


def generate_main(args_values, layers, params, epochs, batch_size):
    """
    Генерация основного кода
    :param args_values: аргументы для данных
    :param layers: слои
    :param params: параметры компиляции
    :param epochs: количество эпох
    :param batch_size: размерность батча
    """
    return f"""{GENERATOR_IMPORT}\n{GENERATOR_PIPELINE}\n{GENERATOR_DATASET}

if __name__ == '__main__':
    {generate_data(**args_values)}
    model = keras.models.Sequential()
    {generate_layers(layers)}
    {generate_compile(params)}
    {generate_train(epochs, batch_size)}
"""
