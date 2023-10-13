/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1 Variation

Разработать метод CreateArray( ), возвращающий сформированный и заполненный массив из N целочисленных элементов  со случайными значениями из диапазона [-1;1].
Разработать метод ShowArray( ) для вывода в консоль массива, ссылка на который передана в параметре. Элементы массива при выводе разделены символом пробела 
и выводятся на экран по десять в строке.
Разработать метод MergeArray( ), формирующий массив C как объединение двух массивов A и В по следующему правилу: 
на чётных позициях массива C стоят элементы с чётных позиций массива А, на нечётных – элементы с нечётных позиций массива В. 
В случае, если массивы А и В имеют различную длину вместо недостающих элементов в массив С на соответствующие позиции записываются нулевые значения. 
Ссылки на массивы А, В и С – параметра метода.
В основной программе при помощи метода CreateArray( ) сформировать массивы А и B из K и M элементов, соответственно (K, M – целые числа вводятся пользователем). 
Используя метод MergeArray( ) по массивам A и B сформировать, массив C. Исходные и результирующий массивы вывести на экран при помощи метода ShowArray( ).

 Дата:      12.10.2023
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

                int[] a, b;
                int k,// the size of A[]
                    m; // the size of B[]

                Console.WriteLine("Введите размер массива A - целое число K:");
                // вводим длину массива A
                while (!int.TryParse(Console.ReadLine(), out k) || k < 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите размер массива A - целое число K:");
                }

                Console.WriteLine("Введите размер массива B - целое число M:");
                // вводим длину массива B
                while (!int.TryParse(Console.ReadLine(), out m) || m < 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите размер массива B - целое число M:");
                }
                // создаем и выводим массив A
                a = CreateArray(k);
                Console.WriteLine("Массив A:");
                ShowArray(a);

                // создаем и выводим массив B
                b = CreateArray(m);
                Console.WriteLine("\nМассив B:");
                ShowArray(b);

                // создаем и выводим массив C
                int[] c;
                MergeArray(a, b, out c);
                Console.WriteLine("\nМассив C:");
                ShowArray(c);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Формирует массив C как объединение двух массивов A и В по следующему правилу: 
        /// на чётных позициях массива C стоят элементы с чётных позиций массива А, 
        /// на нечётных – элементы с нечётных позиций массива В.
        /// В случае, если массивы А и В имеют различную длину вместо недостающих элементов в массив С на соответствующие позиции записываются нулевые значения.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        static void MergeArray(int[] a, int[] b, out int[] c)
        {
            c = new int[Math.Max(a.Length % 2 == 0 ? a.Length - 1 : a.Length /*если массив A четной длины, отрезаем у него последний элемент*/, 
                                 b.Length % 2 == 0 ? b.Length : b.Length - 1) /*если массив B нечетной длины, отрезаем у него последний элемент*/]; // Array C
            for (int i = 0;i < c.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (i >= a.Length) c[i] = 0;
                    else c[i] = a[i];
                }
                else
                {
                    if (i >= b.Length) c[i] = 0;
                    else c[i] = b[i];
                }
            }
        }

        /// <summary>
        ///  Возвращаетсформированный и заполненный массив из N целочисленных элементов  со случайными значениями из диапазона [-1;1]
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int[] CreateArray(int n)
        {
            Random rnd = new Random(); // a generator of random numbers
            int[] res = new int[n]; // an array
            for (int i = 0; i < n; i++)
            {
                res[i] = rnd.Next(-1, 2);
            }
            return res;
        }

        /// <summary>
        ///  Вывод в консоль массива, ссылка на который передана в параметре. 
        ///  Элементы массива при выводе разделены символом пробела и выводятся на экран по десять в строке.
        /// </summary>
        /// <param name="arr"></param>
        static void ShowArray(int[] arr)
        {
            int i; // a counter
            for (i = 0; i < arr.Length - 10; i+= 10)
            {
                Console.WriteLine(string.Join(' ', arr[i..(i + 10)]));
            }
            Console.WriteLine(string.Join(' ', arr[i..arr.Length]));
        }
    } 
}