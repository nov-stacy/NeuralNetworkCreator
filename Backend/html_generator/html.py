import matplotlib.pyplot as plt
import pandas as pd
import cnn
import os


def data_to_html(filename):
    """
    Конвертирование данных в html формат для визуализации
    :param filename: Путь до файла
    """
    data = pd.read_csv(filename, sep=';')
    return data.head(5).to_html()


def logs_to_png(id_user, name, name_logs):
    """
    Создание графика с метриками обучения модели
    :param id_user: имя пользователя
    :param name: название нейронной сети
    :param name_logs: название метрики
    """
    directory = f'logs/{id_user}/{name}/'
    dirs = cnn.file.get_dirs(directory + 'result')
    if len(dirs) == 0: return os.getcwd() + '\\logs\\' + f'{id_user}\\{name}\\{name_logs}.png'
    fig, ax = plt.subplots()
    last_batch = 0
    for epoch in dirs:
        try:
            logs = list(map(float, cnn.file.read_from_file(directory + f'result/{epoch}/{name_logs}').split('\n')))
            batch = list(range(last_batch, last_batch + len(logs)))
            last_batch = last_batch + len(batch)
            ax.plot(batch, logs, label=f'{epoch} epoch')
        except ValueError:
            break
    ax.set_title(f'model {name_logs}')
    ax.set_xlabel('batch')
    ax.set_ylabel(f'{name_logs}')
    ax.legend()
    fig.savefig(directory + f'{name_logs}.png')
    return os.getcwd() + '\\logs\\' + f'{id_user}\\{name}\\{name_logs}.png'
