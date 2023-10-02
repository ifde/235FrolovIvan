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

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Squize int[]
        /// </summary>
        /// <param name="arr"></param>
        static void Squize(ref int[] arr)
        {
            int[] arr_temp = new int[arr.Length]; // temporary array
            int k = 0; // size of arr_temp
            // iterate elements of arr
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // check the condition and squize arr if true
                if ((arr[i] + arr[i + 1]) % 3 == 0)
                {
                    arr_temp[k++] = arr[i] * arr[i + 1];
                    i++;
                }
                else
                {
                    arr_temp[k++] = arr[i];
                    if (i == arr.Length - 2) arr_temp[k++] = arr[i + 1]; // include the last element of arr if no squize was done
                }
            }
            Array.Resize(ref arr_temp, k);

            arr = arr_temp;
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
    }
}