/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      6
   Дата:      23.09.2023
*/

using System.Security.Cryptography;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x;
            do
            {
                Console.Write("Введите x: ");
            } while (!double.TryParse(Console.ReadLine(), out x));

            Sums(x);
            // Console.WriteLine(Math.Pow(2, 1).GetType());
        }

        static void Sums(double x)
        {
            double s, s1 = x * x;
            uint i = 3;
            do
            {
                s = s1;
                s1 = s - Math.Pow(2, i) * Math.Pow(x, i + 1) / Factorial(i + 1);
                i += 2;
            } while (s1 != s);

            double p1 = 0, p;
            i = 0;
            do
            {
                p = p1;
                p1 += Math.Pow(x, i) / Factorial(i);
                i++;
            } while (p != p1);

            Console.WriteLine($"S = {s}\nS = {p}");
        }

        static uint Factorial(uint k)
        {
            uint res = 1;
            for (uint i = 1; i <= k; i++)
            {
                res *= i;
            }
            return res;
        }
    }
}