/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      4
  Дата:      28.09.2023
*/

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения
            do
            {
                Console.Clear();

                uint a0; // a0

                Console.WriteLine("Введите целое неотрицательное число a0:");
                // вводим длину a0
                while (!uint.TryParse(Console.ReadLine(), out a0) || a0 == 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите целое неотрицательное число a0:");
                }

                uint[] arr = Reccur(a0);
                PrintReccur(ref arr);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Вычисление значений рекуррентной функции и добавление их в массив
        /// </summary>
        /// <param name="a0"></param>
        /// <returns></returns>
        static uint[] Reccur(uint a0)
        {
            uint[] arr = new uint[0]; // итоговый массив
            uint a1 = a0; // вычисление следующего элемента

            // на каждом шаге расширяем массив на один элемент и добавляем в него значение,
            // вычисленное по рекуррентной формуле
            do
            {
                Array.Resize(ref arr, arr.Length + 1);
                arr[^1] = a1;
                a0 = a1;
                a1 = a0 % 2 == 0 ? a0 / 2 : (3 * a0 + 1);
            } while (a1 != 1);

            Array.Resize(ref arr, arr.Length + 1);
            arr[^1] = a1;

            return arr;
        }

        /// <summary>
        /// Напечатать массив целочисленыых элементов по 5 элементов на строке
        /// </summary>
        /// <param name="arr"></param>
        static void PrintReccur(ref uint[] arr)
        {
            for (uint i = 0; i < arr.Length; i++)
            {
                if (i % 5 == 4 || i == arr.Length - 1)
                {
                    Console.Write($"[{i}] = {arr[i]}\n");
                }
                else
                {
                    Console.Write($"[{i}] = {arr[i]}, ");
                }
            }
        }
    }
}