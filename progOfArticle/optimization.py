from math import floor, ceil


def road_time(route_len, speed, road):
    """Рассчитывает время одного этапа

    :param route_len: - длина эвакуационного пути
    :param speed: - средняя скорость автобуса
    :param road: - пустой список подготовленный для заполнения
    :return road: - заполнений список содержащий время оного этапа
    """
    for i in route_len:
        road.append(ceil(((i*2)/speed)))


def bus_line(number, busline, people_count):
    """Рассчитывает необходимое количество автобусов для успешной эвакуации

    :param number: - список содержащий количество жителей в определенном населенном пункте
    :param busline: - количество автобусов на линии
    :param people_count: - количество людей, которое автобус сможет везти
    :return busline: - переменная содержащая необходимое количество автобусов для успешной эвакуации
    """
    i = 0
    while i < len(number):
        busline.append(ceil(number[i] / people_count))
        i = i + 1


def r0(road, time1, R0, r, busline,number):
    """Функция для рассчета начального распределения транспорта на маршруты

    :param road: - список содержащий время одного этапа для каждого населенного пункта
    :param time1: - время на эвакуацию
    :param R0: - список для хранения промежуточных значений распределения транспорта
    :param r: - пустой список для хранения итогового распределения
    :param busline: - количестов автобусов на маршруте
    :return r, R0: - возвращает заполненный списки содержащие распределение транспорта на маршруты
    """
    m = 1
    i = 0
    while True:
        if i >= len(road):
            break
        if time1[i] == 0 or road[i] == 0:
            i = i + 1
            R0.append(0)
            r.append(0)
            continue
        if number[i] == 0 or road[i] > time1[i]:
            i = i + 1
            R0.append(0)
            r.append(0)
            continue
        if road[i] * busline[i] <= time1[i]:
            R0.append(m)
            r.append(m)
            i = i + 1
        if i >= len(road):
            break
        if road[i] * busline[i] > time1[i]:
            m = m + 1
            k = (road[i] / m) * busline[i]
            if k <= time1[i]:
                R0.append(m)
                r.append(m)
                m = 1
                i = i + 1



def time_devop(time, minimum):
    """Данный метод предназначен для пересчета времени эвакуации

    :param time: - список содержащий оставшееся время на эвакуацию
    :param minimum: - минимальное время из оставшегося на эвакуацию
    :return time: - возвращает пересчитанный список со временем на эвакуацию
    """
    for j in range(len(time)):
        if time[j] == 0:
            continue
        time[j] = time[j] - minimum


def flight_need(busline, count, time1, road, k):
    """Метод для рассчета необходимого количества рейсов

    :param busline: - количестов автобусов на маршруте
    :param count: - счетчик для транспорта
    :param time1: - время на эвакуацию
    :param road: - список содержащий время одного этапа для каждого населенного пункта
    :param k: - итерационная переменная для перебора населенных пунктов
    :return flight_need: - возвращает необходимое количество маршрутов для успешной эвакуации населения
    """
    return busline[k] - (count * floor((time1[k] / road[k])))
