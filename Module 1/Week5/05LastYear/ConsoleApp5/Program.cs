/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      5
  Дата:      28.09.2023
*/


namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int[] a; // массив
                int n; // размер массив

                Console.WriteLine("Введите размер массива N:");
                // вводим длину массива A
                while (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите размер массива N:");
                }

                var rand = new Random(); // объект класса для генерации случайных чисел
                a = new int[n];

                // заполняем массив A случайными целыми числами от -10 до 10
                for (int i = 0; i < n; i++)
                {
                    a[i] = rand.Next(-10, 11);
                }

                Console.Write("Исходный массив: ");
                PrintArray(a);
                DeleteEven(ref a);
                Console.Write("Массив после удаления четных элементов: ");
                PrintArray(a);



                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static void ChangeArr(int[][] arr)
        {
            arr[0][0] = 0;
        }

        /// <summary>
        /// Сжать массив, удалив из него отрицательные элементы
        /// </summary>
        /// <param name="arr"></param>
        static void SquizeArr(ref int[] arr)
        {
            int k = 0; // новый размер массива
            for (uint i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    arr[k++] = arr[i];
                }
            }
            Array.Resize(ref arr, k);
        }

        /// <summary>
        /// Сжать массив, удалив из него элементы с четными значениями
        /// </summary>
        /// <param name="arr"></param>
        static void DeleteEven(ref int[] arr)
        {
            int k = 0; // новый размер массива
            for (uint i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    arr[k++] = arr[i];
                }
            }
            Array.Resize(ref arr, k);
        }

        /// <summary>
        /// Распечатать массив int[]
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