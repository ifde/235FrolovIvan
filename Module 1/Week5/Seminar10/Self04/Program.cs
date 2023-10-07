/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self04
  Дата:      07.10.2023
*/

//Напишите метод, получающий на вход ссылки на два
//массива целых чисел и добавляющий все чётные элементы первого
//массива в конец второго. Если первый массив null или пустой,
//второй массив не должен меняться, а если второй массив пустой или null
//– по необходимости выделите память для хранения элементов.

using System.Linq.Expressions;

namespace Self04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int[] a, b; // массивы целых чисел
                Console.WriteLine("\nЗаполните массив A:");
                Fill_Array(out a);
                Console.WriteLine("\nЗаполните массив B:");
                Fill_Array(out b);

                InsertEvens(a, ref b);
                Console.WriteLine("\nМассив A:");
                Print_Array(a);
                Console.WriteLine("\nРезультат добавления всех чётных элементов массива A в конец массива B");
                Print_Array(b);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }

        /// <summary>
        /// Заполение массива целыми числами с клавиатуры
        /// </summary>
        /// <param name="a"></param>
        public static void Fill_Array(out int[] a)
        {
            a = new int[100];
            int temp; // очередной элемент массива
            int k = 0; // номер элемента массива
            Console.WriteLine("Введите очередной элемент массива - целое число. Для завершения ввода введите 0.");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out temp))
                {
                    Console.WriteLine("Неверный ввод");
                    Console.WriteLine("Введите очередной элеент массива - целое число. Для завершения ввода введите 0.");
                }
                if (temp != 0)
                {
                    a[k++] = temp;
                    if (k == a.Length)
                    {
                        Array.Resize(ref a, 2 * k);
                    }
                }
            } while (temp != 0);
            Array.Resize(ref a, k);
        }

        /// <summary>
        /// Добавить все чётные элементы первого массива
        /// в конец второго
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static public void InsertEvens(int[] a, ref int[] b)
        {
            if (a == null || a.Length == 0) return; // проверяем, что первый массив не пустой и не null

            if (b == null) b = new int[0];

            int k = b.Length; // длина второго массива. Динамически увеличивается
            Array.Resize(ref b, a.Length + b.Length);

            foreach (int elem in a) // дабавляем элементы из первого массива во второй массив
            {
                if (elem % 2 == 0) b[k++] = elem;
            }
            Array.Resize(ref b, k);

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