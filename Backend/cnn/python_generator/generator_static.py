GENERATOR_IMPORT =  \
"""
import pandas as pd
from keras.utils.np_utils import to_categorical
from sklearn.model_selection import train_test_split
from sklearn.base import BaseEstimator, TransformerMixin
from sklearn.preprocessing import StandardScaler, OneHotEncoder
from sklearn.impute import SimpleImputer
from sklearn.pipeline import Pipeline, FeatureUnion
import keras
"""

GENERATOR_DATASET = \
"""
CLASSIFICATION = 'classification'
REGRESSION = 'regression'
IMAGE = 'image'
TEXT = 'text'
MATRIX = 'matrix'


def get_data(data, target, rate, data_type, type_sl, input_shape):
    data = pd.read_csv(data, sep=';')
    x, y = data.drop([target], axis=1), data[target]
    data = train_test_split(x, y, train_size=rate)
    if type_sl == CLASSIFICATION:
        unique = data[2].unique().shape[0]
        data[2] = to_categorical(data[2], unique)
        data[3] = to_categorical(data[3], unique)
    if data_type == MATRIX:
        return get_data_matrix(*data)
    if data_type == IMAGE:
        return get_image_matrix(*data, input_shape)


def get_data_matrix(x_train, x_test, y_train, y_test):
    pipeline = DataPipeline().fit(x_train)
    x_train, x_test = pipeline.transform(x_train), pipeline.transform(x_test)
    return x_train, x_test, y_train, y_test


def get_image_matrix(x_train, x_test, y_train, y_test, input_shape):
    x_train = (x_train / 255.0).values.reshape(-1, input_shape[0], input_shape[1], 1)
    x_test = (x_test / 255.0).values.reshape(-1, input_shape[0], input_shape[1], 1)
    return x_train, x_test, y_train, y_test
"""

GENERATOR_PIPELINE = \
"""
class DropUniqueAttributes:
    def __init__(self):
        self.__columns = None

    def fit(self, x, y=None):
        self.__columns = [column for column in x if x.shape[0] * 0.2 - x[column].unique().shape[0] <= 0]
        return self

    def transform(self, x):
        return x.drop(self.__columns, axis=1)


class Selector(BaseEstimator, TransformerMixin):
    def __init__(self, attribute_names):
        self.__attribute_names = attribute_names

    def fit(self, x, y=None):
        return self

    def transform(self, x):
        return x[self.__attribute_names]


class Encoder(BaseEstimator, TransformerMixin):
    def __init__(self):
        self.__encoder = OneHotEncoder(handle_unknown='ignore')

    def fit(self, x, y=None):
        return self.__encoder.fit(x)

    def transform(self, x):
        return self.__encoder.transform(x).toarray()


def get_num_attributes(data):
    return [column for column in data if data[column].dtype in ['int64', 'float64']]


def get_cat_attributes(data):
    return [column for column in data if data[column].dtype == 'object']


def get_num_pipeline(data):
    return Pipeline([
        ('selector', Selector(get_num_attributes(data))),
        ('drop', DropUniqueAttributes()),
        ('imputer', SimpleImputer(strategy='median')),
        ('std_scaler', StandardScaler())
    ])


def get_cat_pipeline(data):
    return Pipeline([
        ('selector', Selector(get_cat_attributes(data))),
        ('drop', DropUniqueAttributes()),
        ('imputer', SimpleImputer(strategy="most_frequent")),
        ('cat_encoder', Encoder())
    ])


class DataPipeline:
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
"""
