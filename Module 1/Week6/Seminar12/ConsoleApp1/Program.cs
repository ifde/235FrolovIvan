/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self02
  Дата:      14.10.2023
*/

namespace ConsoleApp1
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
                Console.WriteLine("Введите целое неотрицательное число n - размер первого измерения зубчатого массива:");
                while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
                {
                    Console.WriteLine("Wrong Input");
                    Console.WriteLine("Введите целое неотрицательное число n:");
                }
                arr = new int[n][];
                Random rand = new Random();
                Console.WriteLine("\nИсходный массив:");
                // filling arr[][] with random numbers
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = new int[rand.Next(0, 11)];
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        arr[i][j] = rand.Next(-9, 10);
                        Console.Write($"{arr[i][j]} ");
                    }
                    Console.WriteLine();
                }
                int[] good_lines = Find(arr);
                Console.WriteLine("\nПолученный массив:");
                for (int i = 0; i < arr.Length; i++)
                {
                    if (good_lines.Contains(i))
                    {
                        Console.WriteLine(string.Join(' ', arr[i]));
                    }
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape); 
        }

        static int[] Find(int[][] arr)
        {
            int[] result = new int[arr.Length];
            int k = 0; // counter
            for (int i = 0; i < arr.Length; i++)
            {
                bool flag = true; // flag
                Array.Sort(arr[i]);
                for (int j = 0; j < arr[i].Length - 1; j++)
                {
                    if (Math.Abs(arr[i][j]) == Math.Abs(arr[i][j + 1]))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) result[k++] = i;
            }
            Array.Resize(ref result, k);
            return result;
        }
    }
}