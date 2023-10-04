/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      7
  Дата:      04.10.2023
*/

internal class Program
{

    static int[,] data = { { 20, 21, 23, 22 }, { 24, 20, 27, 19 }, { 25, 18, 24, 20 } }; // разультаты продаж автомобилей
    static string[] department = { "Западный", "Центральный", "Восточный" }; // корелляция названия филиала с его номером в int[,] data

    private static void Main(string[] args)
    {
        // повтор решения 
        do
        {
            Console.Clear();

            Console.WriteLine(PrintSrc());

            Console.WriteLine(PrintMenu());
            string res = PrintResults(Console.ReadLine()); // результат работы команды
            while (res == "Wrong Input.")
            {
                Console.WriteLine(res);
                Console.WriteLine(PrintMenu());
                res = PrintResults(Console.ReadLine()); // результат работы команды
            }


            Console.WriteLine(res);

            Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

    /// <summary>
    /// Вывод исходных данных
    /// </summary>
    /// <returns></returns>
    private static string PrintSrc()
    {
        string st = "Исходные данные:\r\n\\\t";
        foreach (var item in department)
        {
            st += item + "\t";
        }
        st += "\r\n";
        for (int i = 0; i < data.GetLength(0); i++)
        {
            st += i + 1 + "\t";
            for (int j = 0; j < data.GetLength(1); j++)
                st += data[i, j] + "\t\t";
            st += "\r\n";
        }
        return st;
    }

    /// <summary>
    /// Вывод текстовоо меню
    /// </summary>
    /// <returns></returns>
    private static string PrintMenu()
    {
        return @"Выберите, что вы желаете сделать:
     1. Вычислить общее количество автомобилей;
     2. Вывести максимальное количество автомобилей, проданных филиалом за квартал (название филиала и номер квартала);
     3. Найти название филиала, который продал максимальное количество    автомобилей по результатам года (и число проданных);
     4. Найти наиболее успешный квартал (номер квартала и число проданных);
     0. Завершить работу.
     Ваш выбор: ";
    }

    /// <summary>
    /// Результат работы команды mode
    /// </summary>
    /// <returns>Строка, сформированная по результатам работы методов</returns>
    private static string PrintResults(string mode)
    {
        return mode switch
        {
            "0" => "Работка завершена",
            "1" => Mode1(mode),
            "2" => Mode2(mode),
            "3" => Mode3(mode),
            "4" => Mode4(mode),
            _ => "Wrong Input."
        };

    }

    /// <summary>
    /// Ответ для 1 команды
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    static string Mode1(string mode)
    {
        int sum = 0; // общее количество проданных автомобилей
                     // пробегаемся по массиву data и суммируем все значения в нем
        foreach (int cars in data)
        {
            sum += cars;
        }
        return $"Общее количество проданных автомобилей всеми филиалами: {sum}";
    }

    /// <summary>
    /// Ответ для 2 команды
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    static string Mode2(string mode)
    {
        int max_cars = data[0, 0], //  макисмальное количество проданных автомобилей 
                max_i = 0, // номер филиала
                max_j = 0; //  номер квартала
                           // ищем перебором указанные выше три значения
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                if (max_cars < data[i, j])
                {
                    max_cars = data[i, j];
                    max_i = i;
                    max_j = j;
                }
            }
        }
        return $"Максимальное количество в {max_cars} автомобилей " +
            $"было продано филиалом {department[max_i]} в {max_j + 1} квартале.";
    }

    /// <summary>
    /// Ответ для 3 команды
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    static string Mode3(string mode)
    {
        int max_department_sum = 0, // максимальное проданное за год число автомобилей одним из филиалов
                department_with_max_sum = 0; // номер этого филиала

        for (int i = 0; i < data.GetLength(0); i++)
        {
            int department_sum = 0; // проданное за год число автомобилей данным филиалом
            for (int j = 0; j < data.GetLength(1); j++)
            {
                department_sum += data[i, j];
            }
            if (max_department_sum < department_sum)
            {
                max_department_sum = department_sum;
                department_with_max_sum = i;
            }
        }

       return $"За год максимальное количество в {max_department_sum} автомобилей" +
            $" было продано филиалом {department[department_with_max_sum]}.";
    }

    /// <summary>
    /// Ответ для 4 команды
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    static string Mode4(string mode)
    {
        int max_quarter_sum = 0, // максимальное количество автомобилей, проданных за квартал всеми филиалами
        quarter_with_max_sum = 0; // номер квартала, в который было продано максимальное число автомобилей по всем филиалам
        for (int j = 0; j < data.GetLength(1); j++)
        {
            int temp = 0; // суммарное проданное число автомобилей в данном квартале
            for (int i = 0; i < data.GetLength(0); i++)
            {
                temp += data[i, j];
            }
            if (max_quarter_sum < temp)
            {
                max_quarter_sum = temp;
                quarter_with_max_sum = j;
            }
        }

        return $"Наиболее прибыльным стал {quarter_with_max_sum + 1} квартрал," +
            $" в котором было продано {max_quarter_sum} автомобилей.";
    }


}