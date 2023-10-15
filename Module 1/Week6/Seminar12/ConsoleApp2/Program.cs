/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self03

Сформировать таблицу целых чисел размером N строк. Строки имеют
разное количество элементов. Правило формирования длины строки и
значений элементов строки показано на рисунке. Полученную таблицу
построчно выдать на экран. Значение N вводится с клавиатуры и
должно быть нечетным.

  Дата:      14.10.2023
*/

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int[][] arr;
                int n;
                // input n = arr.Length
                Console.WriteLine("Введите нечетное натурльное число n:");
                while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n % 2 == 0)
                {
                    Console.WriteLine("Wrong Input");
                    Console.WriteLine("Введите нечетное натурльное число n:");
                }
                arr = CreateArray(n);

                PrintArray(arr);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Create int[][] Array and fill it according to the task
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int[][] CreateArray(int n)
        {
            int[][] arr = new int[n][];
            int middle = (n - 1) / 2; // middle index
            int k = 1; // counter
            for (int i = 0; i < n; i++)
            {
                arr[i] = new int[i <= middle ? k++ : k--];
                if (i == middle) k -= 2;
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = j + 1;
                }
            }
            return arr;
        }

        /// <summary>
        /// Print int[][]
        /// </summary>
        /// <param name="arr"></param>
        static void PrintArray(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(string.Join(' ', arr[i]));
            }
        }
    }
}