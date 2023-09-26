/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      Self08
   Дата:      25.09.2023
*/

using System.Reflection;

namespace Self07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения
            do
            {
                Console.Clear();
                int n;
                uint k; // вводимое пользователем целое число

                // вводим число
                do
                {
                    Console.WriteLine("Введите целое число:");
                } while (!int.TryParse(Console.ReadLine(), out n));

                do
                {
                    Console.WriteLine("Введите колиество разрядов:");
                } while (!uint.TryParse(Console.ReadLine(), out k) || k > Math.Abs(n));

                Console.WriteLine($"Первые k = {k} разрядов данного числа: {First_k(n, k)}");

                Console.WriteLine("Для завершения программы нажмите ESC");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Найти первые k разрядов числа n
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static int First_k(int n, uint k)
        {
            int temp = Math.Abs(n); // модуль числа n
            

            // "отрезаем" от числа n - k разрядов справа
            for (int i = 0; i < temp.ToString().Length - k; i++)
            {
                n /= 10;
            }

            return n;

        }
    }
}