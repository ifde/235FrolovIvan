/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      3
  Дата:      28.09.2023
*/

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                double[] arr_sin; // массив из членов разложения в ряд функции sin(1)
                uint n;
                Console.WriteLine("Введите количество членов разложения функции sin(1):");
                // вводим длину массива A
                while (!uint.TryParse(Console.ReadLine(), out n) || n < 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите размер массива:");
                }

                arr_sin = new double[n];

                uint i = 1; // счетчик

                // заполняем массив arr_sin
                for (uint j = 0; j < n; j++)
                {
                    arr_sin[j] = (i % 4 == 3 ? -1 : 1) * Math.Pow(1, i) / Fact(i);
                    i += 2;
                }

                PrintArray(arr_sin);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Вычисление Синуса
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static double Sin(double x)
        {
            double res, // результат вычислений
                res1 = 0; // временный результат вычислений
            uint i = 1; // счетчик

            do
            {
                res = res1;
                res1 += (i % 4 == 3 ? -1 : 1) * Math.Pow(x, i) / Fact(i);
                i += 2;
            } while (res1 != res);

            return res;
        }

        /// <summary>
        /// Вычисление факториала натурального числа
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static uint Fact(uint n)
        {
            if (n == 0)
            {
                return 1;
            }
            if (n == 1 || n == 2)
            {
                return n;
            }
            return n * Fact(n - 1);
        }

        /// <summary>
        /// Распечатать массив double[]
        /// </summary>
        /// <param name="arr"></param>
        static void PrintArray(double[] arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.Write("[");
                foreach (double elem in arr)
                {
                    Console.Write($"{elem:f3}, ");
                }
                Console.Write("\b]\n");
            }
        }
    }
}