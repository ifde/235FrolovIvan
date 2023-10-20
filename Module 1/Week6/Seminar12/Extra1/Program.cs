/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Билет №2 Задача 1

Создать двухмерный массив  размером NxM и заполнить его случайным образом числами 0, 1 и 2. 
Запомнить в одномерном массиве  номера строк, которые имеют равное количество нулей и единиц.  
Значения N и M вводятся пользователем. Исходный массив и сформированный массив   выдать на экран.

  Дата:      19.10.2023
*/

namespace Extra1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr;
            int n, m;

            Console.WriteLine("Введите натурльное число N:");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine("Введите натурльное число N:");
            }

            Console.WriteLine("Введите натурльное число M:");
            while (!int.TryParse(Console.ReadLine(), out m) || m < 0)
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine("Введите натурльное число M:");
            }

            arr = new int[n, m];
            var rnd = new Random();
            int[] indices = new int[n]; // массив с номерами строк, которые имеют равное количество нулей и единиц.
            int k = 0; // длина массива indices[]

            for (int i = 0; i < n; i++)
            {
                int zero_num = 0; // количество нулей в строке
                int one_num = 0; // количество единиц в строке
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = rnd.Next(0, 3);
                    if (arr[i, j] == 0) zero_num += 1;
                    if (arr[i, j] == 1) one_num += 1;
                }
                if (zero_num == one_num) indices[k++] = i;
            }

            Array.Resize(ref indices, k);
            PrintArray(arr);
            PrintArray(indices);
        }

        /// <summary>
        /// Print int[,]
        /// </summary>
        /// <param name="arr"></param>
        static void PrintArray(int[,] arr)
        {
            int cnt = 0; // counter
            foreach (int elem in arr)
            {
                Console.Write($"{elem} ");
                cnt++;
                if (cnt % arr.GetLength(0) == 0) Console.WriteLine();
            }
        }

        /// <summary>
        /// Print int[]
        /// </summary>
        /// <param name="arr"></param>
        static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(' ', arr));
        }
    }
}