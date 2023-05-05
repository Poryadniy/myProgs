from math import floor, ceil
import PySimpleGUI as Sq  # Библиотека для создания интерфейса
import numpy as np
import optimization as opt
import schedule as sch
import xlrd


book = xlrd.open_workbook("data.xls")
sheet = book.sheet_by_index(0)
data = []
t_coef = 0


def main():


    layout = [
        [Sq.Text('Please enter bus capacity', size=(25, 1)), Sq.InputText()],
        [Sq.Text('Please enter average bus speed ', size=(25, 1)), Sq.InputText()],
        [Sq.Text('Please enter a time interval', size=(25, 1)), Sq.InputText()],
        [Sq.Submit(), Sq.Cancel()],
        [Sq.Text('-If you want to leave the default interval, enter 60')],
        [Sq.Text('-Enter only real data in the first, the second and the third window, please, else ')],
        [Sq.Text('you can get incorrect answer or a lot of problems')]
    ]  # Расположение текст-боксов и кнопок
    window = Sq.Window('Task', layout)  # Инициализация окна


    while True:

        event, values = window.Read()  # Обновление окна
        if event is None or event == 'Exit':
            break

        people_count = int(values[0])  # Грузоподъемность автобуса
        number = list(map(int, sheet.col_values(0,1,sheet.nrows)))
        route_len = list(map(int, sheet.col_values(1,1,sheet.nrows)))
        time = list(map(int, sheet.col_values(2,1,sheet.nrows)))
        time1 = list(map(int, sheet.col_values(2,1,sheet.nrows)))

        t_coef = int(values[2])
        if int(values[2]) != 1:
            for i in range(len(time)):
                time[i] = int(time[i] * (60 / int(values[2])))
                time1[i] = int(time1[i] * (60 / int(values[2])))

        busline = []  # Кол-во рейсов
        r0 = []  # Начальное распределение
        r = []  # Конечное распределение
        zeros = []
        coef = []
        road = []

        opt.road_time(route_len,int(values[1]),road)
        #print(road)
        opt.bus_line(number, busline, people_count)
        opt.r0(road, time1, r0, r, busline,number)

        while sum(time) > 0:  # Основной цикл, который работает до тех пор, пока есть время на эвакуацию
            '''for i in range(len(number)):
                if number[i] or route_len[i] == 0:
                    continue'''
            minimum = min(x for x in time1 if x is not 0)  # Определяем населенный пункт с минимальным временем на эвакуцаию
            for i in time:
                if i == 0:
                    continue
                if i < minimum:
                 minimum = i

            opt.time_devop(time, minimum)

            i = 1
            k = 0
            bus_need = 0  # Необходимое кол-во машин
            results = []  # Список для хранения результатов рассчета
            flag = 0
            while k < len(number):  # Цикл перебирает маршруты

                """for i in range(len(road)):
                    if road[i] == 0:
                        k = k + 1
                        bus_need = 0
                        flag = 0
                        i = 1
                        continue"""

                if road[k] > time[k] or time[k]  == 0:
                    zeros.append(k)
                    k = k + 1  # Заполняем список нулей индексами тех населенных пунктов, в которых закончилась эвакуация
                elif road[k] == 0:
                    zeros.append(k)
                    k = k + 1  # Заполняем список нулей индексами тех населенных пунктов, в которых закончилась эвакуация
                else:  # Считаем количество рейсов
                    count = r0[k] - 2  # Счетчик
                    if count < 0:
                        count = r0[k] - 1
                    flight_need = opt.flight_need(busline, count, time1, road, k)  # Необходимое кол-во рейсов

                    while True:  # Рассчет необходимого количества машин
                        if flag >= flight_need:
                            break
                        else:
                            if time[k] / road[k] < 1:
                                flag = flag + ceil(time[k] / road[k])
                            else:
                                flag = flag + floor(time[k] / road[k])
                                bus_need = bus_need + 1

                    if bus_need == 0:
                        result = result + count / time[k]
                        results.append(result)  # Сохраняем рассчитаныные коэффициенты
                        k = k + 1
                        bus_need = 0
                        flag = 0
                        i = 1
                        continue

                    a = flight_need / bus_need  # За сколько рейсов будут эвакуированы люди

                    res = []
                    result = 0

                    while True:  # Рассчитываем коэффициенты по эмперической формуле и записываем в список
                        if i % 2 != 0:
                            res.append(ceil(a))
                            result = result + 1 / (ceil(a) * road[k])
                            i = i + 1
                        if sum(res) >= flight_need:
                            break
                        if i % 2 == 0:
                            res.append(floor(a))
                            result = result + 1 / (floor(a) * road[k])
                            i = i + 1
                        if sum(res) == flight_need:
                            break
                    check = max(res, key=lambda x: int(x))
                    if check * road[k] > time[k]:  # Проверка на существование распределения
                    # result = 0
                        continue
                    result = result + count / time[k]
                    results.append(result)  # Сохраняем рассчитаныные коэффициенты
                    k = k + 1
                    bus_need = 0
                    flag = 0
                    i = 1

            new_zeros = list(set(zeros))
            for i in new_zeros:  # Заполняем нулями маршруты, где можно отправить автобус после начала эвакуации
                results.insert(i, 0)
            if not results:
                break

            else:  # Распределяем автобусы
                if r[results.index(max(results))] == 0:
                    continue
                r[results.index(max(results))] = r[results.index(max(results))] - 1
                coef.append(results.index(max(results)))  # Записываем коэффициенты в список

            with open("coef.txt", 'w') as file:  # Запись коэф-ов в файл для чтения
                for line in coef:
                    file.write(str(line) + '\n')

        time = list(map(int, sheet.col_values(2, 1, sheet.nrows)))
        time1 = list(map(int, sheet.col_values(2, 1, sheet.nrows)))

        if int(t_coef) != 1:
            for i in range(len(time)):
                time[i] = int(time[i] * (60 / int(t_coef)))
                time1[i] = int(time1[i] * (60 / int(t_coef)))


        max_time = max(time)
        params = []  # Список для параметров
        d = np.full((max_time, sheet.nrows-1), 0)

        with open('coef.txt', 'r') as file:  # Чтение коэффициентов
            for line in file:
                params.append(int(line))

        i = 0
        flag = 0
        minimum = min(x for x in time if x is not 0)
        while True:  # Пересчет времени
            if i >= sheet.nrows-1:
                for k in range(len(time)):
                    time[k] = time[k] - minimum
                break
            for j in range(time[i]):  # Заполнение матрицы
                d[j][flag] = r[flag]
            i += 1
            flag += 1

        p_flag = 0  # Флаг для параметра
        q = 0
        while q < len(params):  # Цикл составления расписания
            if sum(time) == 0:
                break
            minimum = min(x for x in time if x > 0)
            param = params[p_flag]  # Переменная для хранения параметра, то есть номера маршрута
            #if p_flag != len(params) - 1:  # Проверка на два одинаковых, рядом стоящих параметра
                #if params[p_flag] == params[p_flag + 1]:
                    #p_flag += 1
                    #q += 1
                    #for k in range(len(time)):
                        #time[k] = time[k] - minimum
                        #if time[k] <= 0:
                            #time[k] = 0
                    #continue
            time2 = time1[param] - time[param]  # Пересчет времени
            if r[param] != 0:
                people = sch.people_already_evac(r, param, time1, time, road,int(values[0]))
                # Количество людей, которых успели эвакуировать
                people_need = number[param] - people  # Необходимое к эвакуации кол-во людей
                if people_need == 0 or (int(values[0]) * (floor(time[param] / road[param]))) == 0:
                    # Если некого эвакуировать - кол-во автобусов = 0
                    bus_need = 0
                else:
                    bus_need = sch.bus_need(people_need, time, param, road,int(values[0]))  # Иначе считаем
            else:
                people = 0
                people_need = number[param] - people

                if people_need == 0 or (int(values[0]) * (floor(time[param] / road[param]))) == 0:
                    bus_need = 0
                else:
                    bus_need = sch.bus_need(people_need, time, param, road,int(values[0]))
            for i in range(time2, time1[param]):  # Заполняем матрицу
                d[i][param] = bus_need
            q += 1
            p_flag += 1
            for k in range(len(time)):  # Пересчет времени
                time[k] = time[k] - 1#minimum
                if time[k] <= 0:
                    time[k] = 0


        """Sq.Print("================================================================================")
        Sq.Print("Initial schedule: ", r0)
        Sq.Print("New optimized schedule: ", r)
        Sq.Print("Total number of buses: ", sum(r0))
        Sq.Print("Optimized number of buses: ", sum(r))
        Sq.Print("================================================================================" + "\n")
        Sq.Print("================================================================================")
        Sq.Print("The schedule matrix: " + "\n")
        Sq.Print(d)

        if os.path.exists('result.xlsx'):  # Проверка на успешное создание файла
            Sq.Print("\n" + "The excel file has been created: ")

        Sq.Print("================================================================================")"""
        window.close()

    data = [[j * 0 for j in range(sheet.nrows-1)] for i in range(max_time)]

    for i in range(max_time):
        for j in range (sheet.nrows-1):
            data[i][j] = d[i][j]


    headings = ["Нас. пункт №" + str(i) for i in range(1,sheet.nrows)]
    # ------ Window Layout ------
    layout = [[Sq.Table(values=data, headings=headings, max_col_width=25,
                        auto_size_columns=True,
                        # cols_justification=('left','center','right','c', 'l', 'bad'),       # Added on GitHub only as of June 2022
                        display_row_numbers=True,
                        justification='center',
                        num_rows=25,
                        alternating_row_color='lightblue',
                        key='-TABLE-',
                        selected_row_colors='red on yellow',
                        enable_events=True,
                        expand_x=False,
                        expand_y=True,
                        vertical_scroll_only=False,
                        enable_click_events=True,  # Comment out to not enable header and other clicks
                        tooltip='This is a table')],
              [Sq.Button('Save')],
              [Sq.Text(f'Total number of buses: {sum(r0)}')],
              [Sq.Text(f'Optimized number of buses: {sum(r)}')]]

    # ------ Create Window ------
    window = Sq.Window('The Table Element', layout,
                       # ttk_theme='clam',
                       # font='Helvetica 25',
                       resizable=True
                       )

    # ------ Event Loop ------
    while True:
        event, values = window.read()
        print(event, values)
        if event == Sq.WIN_CLOSED:
            break
        elif event == 'Save':
            if t_coef != 60:
                sch.save_schedule(d,max_time+1,sheet.nrows, t_coef)
            else:
                sch.save_schedule(d, max_time + 1,sheet.nrows,1 )

    window.close()
    
    
    
if __name__ == "__main__":
    main()
