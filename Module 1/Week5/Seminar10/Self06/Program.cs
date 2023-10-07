/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self06
  Дата:      07.10.2023
*/

//В основной программе вводится размер N целочисленного массива, создаётся
//массив, его элементам присваиваются случайные значения из диапазона [-100; 100].
//Выведите исходный массив, после чего вызовите метод для него многократного
//сжатия, выведите количество сжатий и итоговый полученный массив.

namespace Self06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int n; // длина массива
                int[] a; // массив целых чисел длины n
                Console.WriteLine("Введите размер массива:");
                // вводим длину массива A
                while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите размер массива:");
                }

                Fill_Array(out a, n, -100, 100);
                Console.WriteLine("\nИсходный массив:");
                Print_Array(a);
                int cnt; // количество сжатий массива
                RepeatSquize(ref a, out cnt);
                Console.WriteLine("\nСжатый массив:");
                Print_Array(a);
                Console.WriteLine($"\nКоличество сжатий: {cnt}");

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Squize int[]
        /// </summary>
        /// <param name="arr"></param>
        static void Squize(ref int[] arr)
        {
            int k = 0; // size of arr
            // iterate elements of arr
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // check the condition and squize arr if true
                if ((arr[i] + arr[i + 1]) % 3 == 0)
                {
                    arr[k++] = arr[i] * arr[i + 1];
                    i++;
                }
                else
                {
                    arr[k++] = arr[i];
                    if (i == arr.Length - 2) arr[k++] = arr[i + 1]; // include the last element of arr if no squize was done
                }
            }
            Array.Resize(ref arr, k);
        }

        /// <summary>
        /// Repeat Squize(ref int[] arr) until it's not possible anymore
        /// </summary>
        /// <param name="arr"></param>
        static void RepeatSquize(ref int[] arr, out int cnt)
        {
            cnt = -1; // Количество сжатий
            int last_length; // длина массива до сжатия
            do
            {
                cnt++;
                last_length = arr.Length;
                Squize(ref arr);
            } while (arr.Length < last_length); // проверяем, что сжатие есть

        }

        /// <summary>
        /// Заполение массива заданного размера целыми числами от min_value до 10 max_value
        /// </summary>
        /// <param name="a"></param>
        public static void Fill_Array(out int[] a, int n, int min_value, int max_value)
        {
            a = new int[n];
            Random rand = new Random(); // генерация случайных чисел
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(min_value, max_value);
            }
        }

        /// <summary>
        /// Распечатать массив int[]
        /// </summary>
        /// <param name="arr"></param>
        public static void Print_Array(int[] arr)
        {
            if (arr == null) return; // проверяем, что массив не null

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