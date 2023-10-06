/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      02-04Self
  Дата:      06.10.2023
*/

using System.Collections.Immutable;
using System.Linq.Expressions;

namespace _02_04Self
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
                int[] a; // сам массив длины n
                Console.WriteLine("Введите размер массива A:");
                // вводим длину массива A
                while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите размер массива A:");
                }
                a = new int[n];
                Random rand = new Random(); // объект для генерации случайных чисел

                // заполняем массив случайными числами в диапазоне от -2 до 7 включительно
                for (int i = 0; i < n; i++)
                {
                    a[i] = rand.Next(-2, 8);
                }
                Console.WriteLine("\nМассив A:");
                PrintArray(a);
                Array.Sort(a, (a, b) => b - a);
                Console.WriteLine("\nОтсротированный в порядке убывания массив A:");
                PrintArray(a);

                int[] b = new int[a.Length], // четные элементы массива А
                    c = new int[a.Length]; // нечетные элементы массива А
                int len_b = 0, // длина массива B
                    len_c = 0; // длина массива C
                foreach (int elem in a)
                {
                    if (elem % 2 == 0) b[len_b++] = elem;
                    else c[len_c++] = elem;
                }
                Array.Resize(ref b, len_b);
                Array.Resize(ref c, len_c);
                Console.WriteLine("\nЧетные элементы массива A:");
                PrintArray(b);
                Console.WriteLine("\nНечетные элементы массива A:");
                PrintArray(c);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
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