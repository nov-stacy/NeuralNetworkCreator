import pandas as pd
from keras.utils.np_utils import to_categorical
from sklearn.model_selection import train_test_split
from cnn.dataset.pipeline import DataPipeline
import cnn


def get_data(data, target, rate, data_type, type_sl, input_shape=None):
    """
    Получение данных для тренировки нейронной сети
    :param data: ссылка на данные
    :param target: значение признака, который необходимо предсказывать
    :param rate: доля тренировочных данных в датасете
    :param data_type: тип данных
    :param type_sl: тип машинного обучения
    :param input_shape: размер входных данных
    :return: разделенные данные
    """
    data = pd.read_csv(data, sep=';')
    x, y = data.drop([target], axis=1), data[target]
    data = train_test_split(x, y, train_size=rate)

    # тип машинного обучения: классификация
    if type_sl == cnn.CLASSIFICATION:
        unique = data[2].unique().shape[0]
        data[2] = to_categorical(data[2], unique)
        data[3] = to_categorical(data[3], unique)

    # тип данных: обычная матрица объектов-признаков
    if data_type == cnn.MATRIX:
        return get_data_matrix(*data)

    # тип данных: изображение
    if data_type == cnn.IMAGE:
        return get_image_matrix(*data, input_shape)


def get_data_matrix(x_train, x_test, y_train, y_test):
    """
    Получение данных, если это обычная матрица объектов-признаков
    :param x_train: тренировочные фичи
    :param x_test: тестовые фичи
    :param y_train: тренировочные таргеты
    :param y_test: тестовые таргеты
    :return: разделенные данные
    """
    pipeline = DataPipeline().fit(x_train)
    x_train, x_test = pipeline.transform(x_train), pipeline.transform(x_test)
    return x_train, x_test, y_train, y_test


def get_image_matrix(x_train, x_test, y_train, y_test, input_shape):
    """
    Получение данных, если это данные - изображения
    :param x_train: тренировочные фичи
    :param x_test: тестовые фичи
    :param y_train: тренировочные таргеты
    :param y_test: тестовые таргеты
    :param input_shape: размерность изображений
    :return: разделенные данные
    """
    x_train = (x_train / 255.0).values.reshape(-1, input_shape[0], input_shape[1], 1)
    x_test = (x_test / 255.0).values.reshape(-1, input_shape[0], input_shape[1], 1)
    return x_train, x_test, y_train, y_test
