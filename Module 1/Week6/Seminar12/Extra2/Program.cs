/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Билет №2 Задача 2

Создать матрицу целых чисел  размером МхМ и заполнить ее случайными числами из диапазона  от 1 до 2. 
Определить симметричные строки матрицы. 
Симметричной считается строка, элементы которой одинаково читаются при просмотре строки слева направо и справа налево. 
Исходную матрицу и номера симметричных строк вывести  на экран. Значение М вводится с клавиатуры.

  Дата:      19.10.2023
*/

using System.Runtime.InteropServices;

namespace Extra2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr;
            int m;

            Console.WriteLine("Введите натурльное число M:");
            while (!int.TryParse(Console.ReadLine(), out m) || m < 0)
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine("Введите натурльное число M:");
            }

            arr = new int[m, m];
            var rnd = new Random();
            int[] indices = new int[m]; // массив с номерами симметричных строк.
            int k = 0; // длина массива indices[]

            for (int i = 0; i < m; i++)
            {
                bool flag = true; // a flag to determine whether a string is symmetrical
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = rnd.Next(1, 3);
                    if (j >= (m + 1) / 2 && arr[i, j] != arr[i, m - 1 - j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) indices[k++] = i;
            }

            Array.Resize(ref indices, k);
            Console.WriteLine("\nИсходный массив:");
            PrintArray(arr);
            Console.WriteLine("\nНомера искомых строк (отсчет начинается с нуля):");
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