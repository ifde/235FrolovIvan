

namespace Self01_02
{
    internal class Class1
    {
        /// <summary>
        /// Заполение массива заданного размера целыми числами от -10 до 10 включительно
        /// </summary>
        /// <param name="a"></param>
        public static void Fill_Array(int[] a, int n)
        {
            Random rand = new Random(); // генерация случайных чисел
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(-10, 11);
            }
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
        /// Заполение массива заданного размера рациональными числами от -12.25 до 12.25
        /// </summary>
        /// <param name="a"></param>
        public static void Fill_Array(double[] a, int n)
        {
            Random rand = new Random(); // генерация случайных чисел
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 24.5 * rand.NextDouble() - 12.25;
            }
        }

        /// <summary>
        /// Заполение массива вещественными числами с клавиатуры
        /// </summary>
        /// <param name="a"></param>
        public static void Fill_Array(out double[] a)
        {
            a = new double[100];
            double temp; // очередной элемент массива
            int k = 0; // номер элемента массива
            Console.WriteLine("Введите очередной элемент массива - вещественное число. Для завершения ввода введите 0.");
            do
            {
                while (!double.TryParse(Console.ReadLine(), out temp))
                {
                    Console.WriteLine("Неверный ввод");
                    Console.WriteLine("Введите очередной элеент массива - вещественное число. Для завершения ввода введите 0.");
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

        }

        /// <summary>
        /// Распечатать массив int[]
        /// </summary>
        /// <param name="arr"></param>
        public static void Print_Array(int[] arr)
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
        /// Распечатать массив double[] с точностью 2 знака после запятой для каждого элемента
        /// </summary>
        /// <param name="arr"></param>
        public static void Print_Array(double[] arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.Write("[");
                foreach (double elem in arr)
                {
                    Console.Write($"{elem:f2}, ");
                }
                Console.Write("\b\b]\n");
            }
        }
    }
}
