/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self05
  Дата:      06.10.2023
*/

namespace Self05
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
                    a[i] = rand.Next(1, 6);
                }
                Console.WriteLine("\nМассив A:");
                PrintArray(a);

                ModifyArray(a);

                Console.WriteLine("\nМассив A, в котором повторяющиеся элементы заменены на 0:");
                PrintArray(a);

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

        /// <summary>
        /// Удаляет повторяющиеся элементы и заменяет их на 0
        /// </summary>
        /// <param name="arr"></param>
        static void ModifyArray(int[] arr)
        {
            // Каждый последующий элемент сравнивем с данным.
            // Если они совпадают, то зануляем этот последующий элемент
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] == arr[i]) arr[j] = 0;
                }
            }
        }
    }
}