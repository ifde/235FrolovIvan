/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      7
  Дата:      02.10.2023
*/

namespace ConsoleApp07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int n; // size of Array

                Console.WriteLine("Введите целое неотрицательное число:");
                // input a length of arr
                while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите целое неотрицательное число:");
                }

                PrintArray(Numerals(n));

                //int[] test = { 0, 1 };
                //int[][,][] test1 = new int[2][,][];
                //test1[0] = new int[3,3][] { { new int[5], new int[4], new int[3] }, { new int[5], new int[4], new int[3] }, { new int[5], new int[4], new int[3] } };
                //Test(test);
                //Console.WriteLine(test[0]);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Print Array int[]
        /// </summary>
        /// <param name="arr"></param>
        static void PrintArray(int[] arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.Write("[");
                foreach (int elem in arr)
                {
                    Console.Write($"{elem}, ");
                }
                Console.Write("\b\b]\n");
            }
        }

        /// <summary>
        /// Turn an integer number into array of its numerals
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int[] Numerals(int n)
        {
            int[] arr = new int[0]; // resulting arr
            int k = 1; // size of arr
            while (n != 0)
            {
                Array.Resize(ref arr, k);
                arr[k - 1] = n % 10;
                n /= 10;
                k++;
            }
            Array.Reverse(arr);
            return arr;
        }

        static void Test(int[] arr)
        {
            arr[0] = 1;
        }

    }
}