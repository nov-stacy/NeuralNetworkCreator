import tensorflow.keras as keras
import pathlib
from cnn.file import file


class Callback(keras.callbacks.Callback):
    """
    Обработчик обучения нейронной сети (сохранение результатов обучения)
    """

    def __init__(self, id_user, name):
        self.batch, self.loss, self.accuracy, self.epoch = None, None, None, None
        self.directory = f'logs/{id_user}/{name}'
        pathlib.Path(self.directory + '/result').mkdir(parents=True, exist_ok=True)
        pathlib.Path(self.directory + '/weights').mkdir(parents=True, exist_ok=True)
        self.directory += '/result'

    def on_epoch_begin(self, epoch, logs=None):
        directory = self.directory + '/' + str(epoch)
        pathlib.Path(directory).mkdir(parents=True, exist_ok=True)
        pathlib.Path(directory + '/loss').open('w').close()
        pathlib.Path(directory + '/accuracy').open('w').close()
        self.epoch = epoch

    def on_batch_end(self, batch, logs=None):
        file.append_to_file(self.directory + f'/{self.epoch}/loss', logs.get('loss'))
        file.append_to_file(self.directory + f'/{self.epoch}/accuracy', logs.get('accuracy'))

    def on_train_end(self, logs=None):
        with open(self.directory.replace('/result', '/stop.txt'), 'w') as _file: print('yes', file=_file)
