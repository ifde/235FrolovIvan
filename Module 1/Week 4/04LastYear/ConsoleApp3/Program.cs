/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      3
   Дата:      23.09.2023
*/

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            do
            {
                Console.Write("Введите a: ");
            } while (!double.TryParse(Console.ReadLine(), out a));

            do
            {
                Console.Write("Введите b: ");
            } while (!double.TryParse(Console.ReadLine(), out b));

            do
            {
                Console.Write("Введите c: ");
            } while (!double.TryParse(Console.ReadLine(), out c));

            Console.WriteLine(Area(a, b, c, out double s, out double p) ? $"Площадь = {s}\nПериметр = {p}" : "Неверные входные данные");
        }

        static bool Area(double a, double b, double c, out double s, out double p1)
        {
            s = p1 = 0;
            if (a + b <= c || a + c <= b || c + b <= a)
            {
                return false;
            }

            p1 = a + b + c;
            double p = p1 / 2;
            s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return true;

        }
    }
}