using System;
using System.Security.Cryptography.X509Certificates;
/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2
Дата:      15.09.2023
*/


namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double temp;
            Console.WriteLine("Введите числа f, g, e: ");
            string f = double.TryParse(Console.ReadLine(), out temp) ? (temp == 0 ? "err" : temp.ToString()) : "err";
            string g = double.TryParse(Console.ReadLine(), out temp) ? (temp == 25 ? "err" : temp.ToString()) : "err";
            string e = double.TryParse(Console.ReadLine(), out temp) ? (temp.ToString() == g || -temp == int.Parse(g) || -temp == Math.Pow(int.Parse(g), 2) || temp == 0 ? "err" : temp.ToString()) : "err";
            string res = (f == "err" || g == "err" || e == "err") ? "Неверные входные данные" : A(double.Parse(f), double.Parse(g), double.Parse(e)); ;
            Console.WriteLine(res);
        }
        static string A(double f, double g, double e)
        {
            double a = (Math.Pow(f - g, 3) - 7) / (Math.Pow(g + e, 2)) - 7 * (e * f - f * f * g / 3) / (25 - g);
            double x = 43 * 43 * a - 42 * 42 * g / 27.3 + (16 + g) / (g - e);
            double w = x / 100 + 25 * 25 / x + a / (3 * f) - (g + e * e) / (e + g * g);
            double h = g - f * f - 7 * e * e * w / 3 - x * x / (4.5 * f * e);
            string res = (x == 0) ? "Неверные входные данные" : $"{a:f3}\n{x:f3}\n{w:f3}\n{h:f3}";
            return res;
        }
    }
}