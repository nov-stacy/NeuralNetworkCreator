import json
import os


def json_from_text(text):
    """
    Получение json данных из текста
    :param text: Текст
    :return: Словарь
    """
    return json.loads(text)


def read_from_file(path):
    """
    Получение данных из файла
    :param path: Путь до файла
    :return: Текст, который был получен из файла
    """
    try:
        with open(path) as file:
            text = file.read()
        return text.rstrip()
    except FileNotFoundError:
        return ""


def get_dirs(path):
    """
    Получение списка файлов в папке
    :param path: Путь до папки
    :return: Список файлов
    """
    return os.listdir(path)


def append_to_file(path, text):
    with open(path, 'a') as file:
        print(text, file=file)
