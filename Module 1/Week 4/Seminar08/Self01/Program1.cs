/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      Self01
   Дата:     30.09.2023
*/

namespace Self01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения
            do
            {
                Console.Clear();
                int k; // счетчик для функций PiFormula1 и PiFormula2
                int c; // команда, по которой выбирается формула
                Console.WriteLine("Выберите формулу для вычисления Pi");
                Console.WriteLine("Нажмите 1 для формулы Бэйли-Боруэйна-Плаффа");
                Console.WriteLine("Нажмите 2 для формулы с использованием кратных рядов");

                // вводим число
                while (!int.TryParse(Console.ReadLine(), out c) && c != 1 && c!= 2)
                {
                    Console.WriteLine("Неверное значение. Повторите ввод");
                }

                // Выводим Pi по первой формуле
                if (c == 1)
                {
                    Console.WriteLine($"Pi = {PiFormula1(out k)}");
                    Console.WriteLine($"Количество итераций = {k}");
                }
                // Выводим Pi по первой формуле
                else if (c == 2)
                {
                    Console.WriteLine($"Pi = {PiFormula2(out k)}");
                    Console.WriteLine($"Количество итераций = {k}");
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Вычисление Pi по формуле Бэйли-Боруэйна-Плаффа
        /// </summary>
        /// <returns></returns>
        static double PiFormula1(out int i)
        {
            double pi, // вычисленное значение
                pi1 = 0; // временное значение
            i = 0; // счетчик
            do
            {
                pi = pi1;
                pi1 += Math.Pow(16, -i) * 4 / (8 * i + 1) - Math.Pow(16, -i) * 2 / (8 * i + 4)
                    - Math.Pow(16, -i) * 1 / (8 * i + 5) - Math.Pow(16, -i) * 1 / (8 * i + 6);
                i++;
            } while (pi1 != pi);

            return pi;
        }

        /// <summary>
        /// Вычисление Pi с использованием кратных рядов
        /// </summary>
        /// <returns></returns>
        static double PiFormula2(out int k)
        {
            double pi, // вычисленное значение
                pi1 = 0; // временное значение
            k = 1; // счетчик
            do
            {
                pi = pi1;
                for (int m = 1; m <= k; m++)
                {
                    pi1 += 360 / (m * Math.Pow(k + 1, 3));
                }
                k++;
            } while (pi1 != pi);

            pi = Math.Pow(pi, 1 / 4);

            return pi;
        }
    }
}