/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      3
Дата:        17.09.2023
*/

using System.Transactions;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a, delta;
            do
            {
                Console.Write("Input A: ");
            } while (!double.TryParse(Console.ReadLine(), out a) || a < 0);

            do
            {
                Console.Write("Input Delta: ");
            } while (!double.TryParse(Console.ReadLine(), out delta) || delta <= 0 || delta > a);

            Console.WriteLine(FindArea(a, delta));
        }

        static double FindArea (double a, double delta)
        {
            double sum = 0;
            double curr = 0;
            do
            {
                sum += 0.5 * delta * (Func(curr) + Func(curr + delta));
                curr += delta;
            } while (curr + delta < a);
            sum += 0.5 * (a - curr) * (Func(curr) + Func(a));

            return sum;
        }

        static double Func (double x)
        {
            return x * x;
        }
    }
}