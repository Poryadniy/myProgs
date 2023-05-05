from math import floor, ceil
import pandas as pd


def people_already_evac(r, param, time1, time, road,capacity):
    """Метод, который рассчитывает число эвакуированных людей за определенный промежуток времени. Результат используется
    при рассчете оставшегося количества людей на эвакуацию

    :param r: список хранящий итоговое распределение транспорта по маршрутам
    :param param: - переменная для хранения параметра, то есть номера маршрута
    :param time1: - время на эвакуацию
    :param time: - время на эвакуацию с учетом прощедшего времени
    :param road: - список хранящий время одного этапа для каждого населенного пункта
    :return people_already_evac:  - возвращает число эвакуированных людей за определенный промежуток времени
    """
    return (r[param] * capacity * (time1[param] - time[param])) / road[param]


def bus_need(people_need, time, param, road,capacity):
    """Рассчитывает необходимое количество автобусов для успешной эвакуации

    :param people_need: - оставшееся количество людей на эвакуацию после n-го количества этапов
    :param time: - время на эвакуацию с учетом прощедшего времени
    :param param: - переменная для хранения параметра, то есть номера маршрута
    :param road: - список хранящий время одного этапа для каждого населенного пункта
    :return bus_need: - возвращает необходимое количество автобусов для успешной эвакуации
    """
    return ceil(people_need / (capacity * (floor(time[param] / road[param]))))


def save_schedule(d, rows, cols, coef):
    """Метод предназначенный для сохранения расписания в Excel файл с расширением xlsx

    :param d: - матрица, которая хранит расписание. Здесь строками являются часы эвакуации, столбцами - нас-ые пункты
    :return: - данный метод ничего не возвращает
    """
    df = pd.DataFrame(d)  # Содаем датафрейм
    df.index = [i*int(coef) for i in range(1,rows)]
    df.columns = [j for j in range(1, cols)]
    filepath = 'result.xlsx'  # Прописываем имя и расширение файла
    df.to_excel(filepath, index=1)  # Сохраняем результат в excel файл
