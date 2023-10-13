/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self07
 Дата:      13.10.2023
*/

using System.Numerics;

namespace Self07
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // повтор решения 
            do
            {
                Console.Clear();

                char[,] matr;
                int n; // size of matr[]
                Console.WriteLine("Введите тип матрицы: ");
                while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
                {
                    Console.WriteLine("Неверный ввод");
                    Console.WriteLine("Введите тип матрицы: ");
                }

                matr = CreateMatr(n);
                Console.WriteLine("\nИсходная матрица: ");
                Print_Array(matr);

                char[] diagonal_symbols = new char[n]; // an array for diagonal symbols
                for (int i = 0; i < n; i++)
                {
                    diagonal_symbols[i] = matr[i, i];
                }

                Console.WriteLine("\nДаигональная строка:");
                Console.WriteLine(diagonal_symbols);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }

        /// <summary>
        /// Распечатать массив char[n,n]
        /// </summary>
        /// <param name="arr"></param>
        public static void Print_Array(char[,] arr)
        {
            if (arr == null) return; // проверяем, что массив не null

            if (arr.Length == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(0); j++)
                    {
                        Console.Write($"{arr[i, j],2}");
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Формаирует массив char[] по заданному в задаче правилу
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static char[,] CreateMatr(int n)
        {
            char[,] matr = new char[n, n];
            Random rand = new Random(); // random numbers
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i % 2 == 0) matr[i, j] = (char)('a' + rand.Next(0, 'z' - 'a' + 1));
                    else matr[i, j] = (char)rand.Next('1', '9');
                }

            }
            return matr;
        }
    }
}