/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self 05. Задание 5.
Дата:      16.09.2023
*/

namespace Self_05_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            Console.WriteLine("Введите a: ");
            double.TryParse(Console.ReadLine(), out a);
            Console.WriteLine("Введите b: ");
            double.TryParse(Console.ReadLine(), out b);
            Console.WriteLine("Введите c: ");
            double.TryParse(Console.ReadLine(), out c);

            if (a == 0)
            {
                if (b == 0)
                {
                    if (c != 0)
                    {
                        Console.WriteLine("No solutions");
                    }
                    else
                    {
                        Console.WriteLine("Infinity");
                    }
                }
                else
                {
                    Console.WriteLine(-c / b);
                }
            }
            else
            {
                double d = b * b - 4 * a * c;
                if (d < 0)
                {
                    Console.WriteLine("No real solutions");
                }
                if (d == 0)
                {
                    Console.WriteLine(-b / (2 * a));
                }
                if (d > 0)
                {
                    Console.WriteLine($"x1 = {(-b - Math.Sqrt(d)) / (2 * a)}\nx2 = {(-b + Math.Sqrt(d)) / (2 * a)}");
                }
            }
        }

    }
}