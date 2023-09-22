/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      4 DIY
Дата:        22.09.2023
*/

namespace DIY04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            do
            {
                Console.Write("Введите натуральное x: ");
            } while (!double.TryParse(Console.ReadLine(), out x));

            do
            {
                Console.Write("Введите натуральное y: ");
            } while (!double.TryParse(Console.ReadLine(), out y));

            Console.WriteLine(F(x, y));
        }

        static double F(double x, double y)
        {
            if (x < y && x > 0)
            {
                return x + Math.Sin(y);
            }
            else if (y < x && x < 0)
            {
                return y - Math.Cos(x);
            }
            else
            {
                return 0.5 * x * y;
            }
        }
    }
}