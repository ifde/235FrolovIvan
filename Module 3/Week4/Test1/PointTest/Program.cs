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

                    Func<double, double> f = delegate (double a)
                    {
                        return a;
                    };

                    Console.Write($"\nf1(x)   ");
                    foreach (double eps in new double[] { 0.1, 0.01, 0.005, 0.001 })
                    {
                        Console.Write(point.IsNearFunc(f, eps) ? $"Yes      |": $"No       |");
                    }
                    PrintFunc(x => -x * x + 4, "f1(x)", point);
                    PrintFunc(x => x * Math.Sin(x), "f2(x)", point);
                    PrintFunc(x => Math.Pow(x, 4) / 4 - Math.Pow(x, 3) / 3 - Math.Pow(x, 2), "f3(x)", point);


                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.ParamName);
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