/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2
  Дата:      28.09.2023
*/


namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // повтор решения 
            do
            {
                Console.Clear();

                uint k; // длина массива arr

                Console.WriteLine("Введите размер массива:");
                // вводим длину массива A
                while (!uint.TryParse(Console.ReadLine(), out k) || k < 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите размер массива:");
                }

                char[] arr = new char[k]; // массив символов

                var rand = new Random(); // объект класса для генерации случайных чисел

                // заполняем массив символов случайными случайными заглавными символами латинского алфавита
                for (int i = 0; i < k; i++)
                {
                    arr[i] = (char)rand.Next('A', 'Z' + 1);
                }

                Console.Write("Исходный массив: ");
                PrintArray(arr); // печатаем массив arr

                char[] arr_copy = arr.Clone() as char[];
                
                Array.Sort(arr_copy);

                Console.Write("Отсортированный массив: ");
                PrintArray(arr_copy); // печатаем массив arr_copy

                Array.Reverse(arr_copy);

                Console.Write("Отсортированный и перевернутый массив: ");
                PrintArray(arr_copy); // печатаем массив arr_copy

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }

        /// <summary>
        /// Распечатать массив char[]
        /// </summary>
        /// <param name="arr"></param>
        static void PrintArray(char[] arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.Write("[");
                foreach (char elem in arr)
                {
                    Console.Write($"{elem}, ");
                }
                Console.Write("\b\b]\n");
            }
        }
    }
}