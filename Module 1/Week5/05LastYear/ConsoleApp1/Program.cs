

internal class Program
{
    private static void Main(string[] args)
    {
        // повтор решения 
        do
        {
            Console.Clear();

            uint[] a, b; // массивы
            uint l_a, l_b; // размеры массивов

            Console.WriteLine("Введите размер массива A:");
            // вводим длину массива A
            while (!uint.TryParse(Console.ReadLine(), out l_a))
            {
                Console.WriteLine("Wrong input.");
                Console.WriteLine("Введите размер массива A:");
            }

            Console.WriteLine("Введите размер массива B:");
            // вводим длину массива B
            while (!uint.TryParse(Console.ReadLine(), out l_b))
            {
                Console.WriteLine("Wrong input.");
                Console.WriteLine("Введите размер массива B:");
            }

            var rand = new Random(); // объект класса для генерации случайных чисел
            a = new uint[l_a + l_b + 1];
            b = new uint[l_b];

            Console.Write("Массив A: [");
            // заполняем массив A случайными числами от 10 до 50
            for (int i = 0; i < l_a; i++)
            {
                a[i] = (uint)rand.Next(10, 51);
                Console.Write(i != l_a - 1 ? $"{a[i]}, " : $"{a[i]}]");
            }
            Console.Write(l_a == 0 ? "]\n" : "\n");

            Console.Write("Массив B: [");
            // заполняем массив B случайными числами от 10 до 50
            for (int i = 0; i < l_b; i++)
            {
                b[i] = (uint)rand.Next(10, 51);
                Console.Write(i != l_b - 1 ? $"{b[i]}, " : $"{b[i]}]");
            }
            Console.Write(l_b == 0 ? "]\n" : "\n");

            uint cnt = 0; // счетчик количества элементов, добавленных в массив A
            // перебираем элементы массива B
            foreach (uint elem in b)
            {
                // если очередной элемент массива B четный, то добавляем его в массив A
                if (elem % 2 == 0)
                {
                    a[l_a + cnt] = elem;
                    cnt++;
                }
            }

            Console.Write("Модифицирванный массив A: [");
            foreach (uint elem in a)
            {
                Console.Write(elem == 0 ? "\b\b]" : $"{elem}, ");
            }

            Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}