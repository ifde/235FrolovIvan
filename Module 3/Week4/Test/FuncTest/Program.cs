/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Вариант:     XXX
Дата:       03.02.2024
*/

using System.Net.Http.Headers;
using System.Xml;
using Functions;

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
                    Function f = new Function(x => Math.Sin(x));
                    Function g = new Function(y => y * y + y);

                    CompFunction gf = new CompFunction(f, g);

                    double a, b, delta;

                    Console.WriteLine("Input a:");
                    while (true)
                    {
                        if (double.TryParse(Console.ReadLine(), out a)) break;
                        Console.WriteLine("Wrong input. Try again.");
                    }

                    Console.WriteLine("Input b (b > a):");
                    while (true)
                    {
                        if (double.TryParse(Console.ReadLine(), out b) && b > a) break;
                        Console.WriteLine("Wrong input. Try again.");
                    }

                    Console.WriteLine("Input delta (0 < delta < 1):");
                    while (true)
                    {
                        if (double.TryParse(Console.ReadLine(), out delta) && delta > 0 && delta < 1) break;
                        Console.WriteLine("Wrong input. Try again.");
                    }

                    for (double t = a; t <= b; t += delta)
                    {
                        Console.WriteLine($"x = {t:f3}, g(f(x)) = {gf.GetValue(t):f3}");
                    }
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
    }
}