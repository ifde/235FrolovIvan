/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self05
  Дата:      30.09.2023
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

                int a; // числитель дроби
                int b; // знаменатель дроби

                Console.WriteLine("Введите числитель дроби:");
                // вводим количество ступенек треугольника
                while (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите числитель дроби:");
                }

                Console.WriteLine("Введите знаменатель дроби:");
                // количество секций ёлочки
                while (!int.TryParse(Console.ReadLine(), out b) || b == 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите знаменатель дроби:");
                }

                int gcd = Gcd(a, b);
                Console.WriteLine($"Результат: {a / gcd} / {b / gcd}");

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// НОД двух целых чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int Gcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (b == 0)
            {
                return a;
            }

            return Gcd(b, a % b);
        }

        /// <summary>
        /// НОК двух целых чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int Lcd(int a, int b)
        {
            return a * b / Gcd(a, b);
        }
    }
}