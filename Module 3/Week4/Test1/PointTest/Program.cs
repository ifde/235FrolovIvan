/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Вариант:     XXX
Дата:       03.02.2024
*/

using System.Net.Http.Headers;
using System.Xml;
using PointLib;

namespace FuncTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                try
                {

                    double a, b;

                    Console.WriteLine("Input x:");
                    while (true)
                    {
                        if (double.TryParse(Console.ReadLine(), out a)) break;
                        Console.WriteLine("Wrong input. Try again.");
                    }

                    Console.WriteLine("Input y:");
                    while (true)
                    {
                        if (double.TryParse(Console.ReadLine(), out b)) break;
                        Console.WriteLine("Wrong input. Try again.");
                    }

                    Point point = new Point(a, b);

                    Console.Write("        ");
                    foreach (double eps in new double[] { 0.1, 0.01, 0.005, 0.001 })
                    {
                        Console.Write($"e = {eps, -5}|");
                    }

                    PrintFunc(x => -x * x + 4, "f1(x)", point);
                    PrintFunc(x => x * Math.Sin(x), "f2(x)", point);
                    PrintFunc(x => Math.Pow(x, 4) / 4 - Math.Pow(x, 3) / 3 - Math.Pow(x, 2), "f3(x)", point);
                    Console.WriteLine();

                    Func<double, double> f = x => x;
                    Console.WriteLine("e =    |{0,5}|{1,5}|{2,5}|{3,5}|", 0.1, 0.01, 0.005, 0.001);
                    Console.WriteLine("f(x) = |{0,5}|{1,5}|{2,5}|{3,5}|", point.IsNearFunc(f, 0.1), point.IsNearFunc(f, 0.01), point.IsNearFunc(f, 0.005), point.IsNearFunc(f, 0.001));



                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"One of the arguments is null");
                }
                catch (Exception)
                {
                    Console.WriteLine("Возникла непредвиденная ошибка.");
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static void PrintFunc(Func<double, double> f, string name, Point point)
        {
            Console.Write($"\n{name}   ");
            foreach (double eps in new double[] { 0.1, 0.01, 0.005, 0.001 })
            {
                Console.Write(point.IsNearFunc(f, eps) ? $"Yes      |" : $"No       |");
            }
        }
    }
}