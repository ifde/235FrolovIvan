/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      7
   Дата:      26.09.2023
*/

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения
            do
            {
                Console.Clear();
                uint a, b; // вводимые пользователем целые неотрицательные числа
                uint k; 

                // вводим число a
                do
                {
                    Console.WriteLine("Введите целое число неотрицательное a:");
                } while (!uint.TryParse(Console.ReadLine(), out a));

                // вводим число b
                do
                {
                    Console.WriteLine("Введите целое неотрицательное число b:");
                } while (!uint.TryParse(Console.ReadLine(), out b));

                Console.WriteLine($"НОД чисел {a} и {b} равен {gcd(a, b)}");
                Console.WriteLine($"НОК чисел {a} и {b} равен {lcd(a, b)}");

                Console.WriteLine("Для завершения программы нажмите ESC");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// НОД Числа
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static uint gcd(uint a, uint b)
        {
            if (b == 0)
            {
                return a;
            }

            return gcd(b, a % a);
        }

        /// <summary>
        /// НОК числа
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static uint lcd(uint a, uint b)
        {
            return a * b / gcd(a, b);
        }
    }
}