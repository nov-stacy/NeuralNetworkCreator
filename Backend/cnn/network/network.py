import tensorflow.keras as keras
from cnn.network.callback import Callback
from cnn.params import *
import shutil


LAYER_NAMES = {
    'Dense': keras.layers.Dense,
    'Flatten': keras.layers.Flatten,
    'Dropout': keras.layers.Dropout,
    'MaxPooling1D': keras.layers.MaxPooling1D,
    'MaxPooling2D': keras.layers.MaxPooling2D,
    'Conv1D': keras.layers.Conv1D,
    'Conv2D': keras.layers.Conv2D
}


def create_layer(name, params):
    """
    Создание слоев
    :param name: имя слоя
    :param params: параметры
    :return: объект слоя
    """
    return LAYER_NAMES[name](**params)


class NeuralNetwork:
    """
    Класс описывающий нейронную сеть
    """

    def __init__(self, id_user, name, layers):
        """
        :param id_user: имя пользователя
        :param name: название модели
        :param layers: слои
        """
        self.id_user, self.name = id_user, name
        self.model = keras.models.Sequential()
        for layer in layers:
            self.model.add(create_layer(layer['type'], change_layer_params(layer['params'])))

    def compile(self, params):
        """
        Компиляция
        :param params: параметры компиляции
        """
        self.model.compile(**change_params(params))
        return self

    def fit(self, data, epochs, batch_size):
        """
        Обучение
        :param batch_size: размер батча
        :param data: данные
        :param epochs: количество эпох
        """
        self.model.fit(
            data[0], data[2], epochs=epochs, validation_data=(data[1], data[3]), batch_size=batch_size,
            callbacks=[Callback(self.id_user, self.name)]
        )

        path = f'logs/{self.id_user}/{self.name}/weights'
        self.model.save_weights(f'{path}/model')  # сохранение весов
        shutil.make_archive(path, 'zip', path)  # создание архива

    def get_information(self):
        """
        Получение данных по нейронной сети
        """
        result = list()
        self.model.summary(print_fn=lambda x: result.append(x))
        return "\n".join(result[1:])
