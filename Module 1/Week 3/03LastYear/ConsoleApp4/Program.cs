/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      4
Дата:        18.09.2023
*/

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a, x, eps;
            do
            {
                Console.Write("Input A: ");
            } while (!double.TryParse(Console.ReadLine(), out a));

            if (!Root(a, out x, out eps))
            {
                Console.WriteLine("Неверные данные");
            } 
            else
            {
                Console.WriteLine($"Sqrt({a}) = {x:f3}");
            }

        }

        static bool Root (double a, out double x, out double eps)
        {
            x = a / 2;
            double l1, l2 = x;
            eps = 0;
            if (a < 0)
            {
                return false;
            }
            do
            {
                l1 = l2;
                l2 = (l1 + a / l1) / 2;
                eps = l2 - l1;
            } while (eps != 0);
            x = l2;
            return true;
        }
    }
}