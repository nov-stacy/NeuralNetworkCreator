from sklearn.base import BaseEstimator, TransformerMixin
from sklearn.preprocessing import StandardScaler, OneHotEncoder
from sklearn.impute import SimpleImputer
from sklearn.pipeline import Pipeline, FeatureUnion


class DropUniqueAttributes:
    """
    Класс для удаления уникальных признаков из данных
    """

    def __init__(self):
        self.__columns = None

    def fit(self, x, y=None):
        self.__columns = [column for column in x if x.shape[0] * 0.2 - x[column].unique().shape[0] <= 0]
        return self

    def transform(self, x):
        return x.drop(self.__columns, axis=1)


class Selector(BaseEstimator, TransformerMixin):
    """
    Класс для выбора признаков из данных
    """

    def __init__(self, attribute_names):
        self.__attribute_names = attribute_names

    def fit(self, x, y=None):
        return self

    def transform(self, x):
        return x[self.__attribute_names]


class Encoder(BaseEstimator, TransformerMixin):
    """
    Класс для one-hot энкодинга категориальных признаков
    """

    def __init__(self):
        self.__encoder = OneHotEncoder(handle_unknown='ignore')

    def fit(self, x, y=None):
        return self.__encoder.fit(x)

    def transform(self, x):
        return self.__encoder.transform(x).toarray()


def get_num_attributes(data):
    """
    Получение числовых признаков
    :param data: данные
    :return: список числовых признаков
    """
    return [column for column in data if data[column].dtype in ['int64', 'float64']]


def get_cat_attributes(data):
    """
    Получение категориальных признаков
    :param data: данные
    :return: список категориальных признаков
    """
    return [column for column in data if data[column].dtype == 'object']


def get_num_pipeline(data):
    """
    Обработка числовых признаков
    :param data: данные
    :return: объект для обработки числовых признаков
    """
    return Pipeline([
        ('selector', Selector(get_num_attributes(data))),
        ('drop', DropUniqueAttributes()),
        ('imputer', SimpleImputer(strategy='median')),
        ('std_scaler', StandardScaler())
    ])


def get_cat_pipeline(data):
    """
    Обработка категориальных признаков
    :param data: данные
    :return: объект для обработки категориальных признаков
    """
    return Pipeline([
        ('selector', Selector(get_cat_attributes(data))),
        ('drop', DropUniqueAttributes()),
        ('imputer', SimpleImputer(strategy="most_frequent")),
        ('cat_encoder', Encoder())
    ])


class DataPipeline:
    """
    Класс для обработки данных
    """
    def __init__(self):
        self.__pipeline = None

    def fit(self, x_train):
        self.__pipeline = FeatureUnion(transformer_list=[
            ('num_pipeline', get_num_pipeline(x_train)),
            ('cat_pipeline', get_cat_pipeline(x_train))
        ]).fit(x_train)
        return self

    def transform(self, data):
        return self.__pipeline.transform(data)
