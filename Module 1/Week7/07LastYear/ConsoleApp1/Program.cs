using System;
using System.IO;
using System.Text;
/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1
 Дата:       10.10.2023
*/

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                string path = @"..\..\..\Data.txt";
                Random rand = new Random(); // генерация случайных чисел
                int[] data = new int[rand.Next(1, 50)];
                Console.WriteLine($"Длина массива = {data.Length}");

                // заполняем массив случайными числами от 1 до 100
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = rand.Next(10, 100);
                }

                // записываем данные в файл
                try
                {
                    ArrayToFile(data, path);
                }
                catch
                {
                    Console.WriteLine("Ошибка при работе с файлом");
                }

                // Open the file to read from
                if (File.Exists(path))
                {
                    //string[] lines = File.ReadAllLines(path);
                    //string text = string.Join(' ', lines);
                    string readText = File.ReadAllText(path);

                    string[] stringValues = readText.Split(' ');
                    int[] arr = StringArrayToIntArray(stringValues);

                    Console.WriteLine("Прочитанный из файла массив:");
                    Print_Array(arr);

                    int[] odds, evens;
                    CreateOddsEvensIndexArrays(arr, out odds, out evens);
                    for (int i = 0; i < odds.Length; i++)
                    {
                        arr[odds[i]] = 0;
                    }
                    Console.WriteLine("Заменили нечетные числа нулями");
                    Print_Array(arr);
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
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

        /// <summary>
        /// По массиву создает два индексных массива, содержащих индексы элементов с чётными и нечётными значениями
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="odds"></param>
        /// <param name="evens"></param>
        public static void CreateOddsEvensIndexArrays(int[] arr, out int[] odds, out int[] evens)
        {
            odds = new int[arr.Length];
            evens = new int[arr.Length];
            int a = 0, // length of odds[] 
                b = 0; // length o evens[]
            for (int i = 0; i <  arr.Length; i++)
            {
                if (arr[i] % 2 == 0) evens[a++] = i;
                else odds[b++] = i;
            }
            Array.Resize(ref odds, a);
            Array.Resize(ref evens, b);
        }

        /// <summary>
        /// Записывает целочисленный массив в файл по 5 элементов на строке
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="path"></param>
        public static void ArrayToFile(int[] arr, string path)
        {
            string res = ""; // строка для записи в файл
            int i = 0;
            // заполняем строку
            for (; i < arr.Length - 5; i += 5)
            {
                res += $"{arr[i]} {arr[i + 1]} {arr[i + 2]} {arr[i + 3]} {arr[i + 4]}\n";
            }
            res += string.Join(' ', arr[i..arr.Length]);

            File.WriteAllText(path, res);

        }

        /// <summary>
        /// Преобразует массив строк в массив целых чисел
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int[] StringArrayToIntArray(string[] str)
        {
            int[] arr = null;
            if (str.Length != 0)
            {
                arr = new int[0];
                foreach (string s in str)
                {
                    int tmp;
                    if (int.TryParse(s, out tmp))
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = tmp;
                    }
                }   
            }
            return arr;
        }
    } // end of Program
}