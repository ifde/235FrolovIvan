/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      6
  Дата:      01.10.2023
*/

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int[] arr; // array
                uint n; // size of Array

                Console.WriteLine("Введите размер массива:");
                // input a length of arr
                while (!uint.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите размер массива:");
                }

                var rand = new Random(); // Random numbers generator
                arr = new int[n];

                // Filling arr with random integers from -10 to 10
                for (int i = 0; i < n; i++)
                {
                    arr[i] = rand.Next(-10, 11);
                }

                Console.WriteLine("Исходный массив:");
                PrintArray(arr);

                RepeatSquize(ref arr);
                Console.WriteLine("Сжатый массив:");
                PrintArray(arr);

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
        /// Repeat Squize(ref int[] arr) until it's not possible anymore
        /// </summary>
        /// <param name="arr"></param>
        static void RepeatSquize(ref int[] arr)
        {
            int[] arr_temp;
            do
            {
                arr_temp = arr.Clone() as int[];
                Squize(ref arr);
            } while (arr.Length < arr_temp.Length);
            
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
    }
}