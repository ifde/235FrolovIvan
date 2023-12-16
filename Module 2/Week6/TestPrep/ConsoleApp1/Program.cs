/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Вариант:     XXX
Дата:        16.12.23
*/
using DotClassLibrary;
using System.Collections.Immutable;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // repeat program
            do
            {
                Console.Clear();

                try
                {
                    SetOfPoints points; // set of points
                    string[] data = File.ReadAllText("dots.txt").Split(new string[] { "\r\n", " " }, StringSplitOptions.RemoveEmptyEntries); // an array containing string data
                                                                                                                    // for each point from the dots.txt file
                    Console.WriteLine("Считанные координаты точек:");
                    foreach (string line in data) { Console.WriteLine(line); }

                    points = new SetOfPoints(data);
                    Console.WriteLine(points);

                    double xa, ya; // coordinates of point A

                    // input xa
                    Console.WriteLine("Введите вещественное число - абсциссу точки A.");
                    while (true)
                    {
                        if (double.TryParse(Console.ReadLine(), out xa)) break;
                        Console.WriteLine("Введенное значение недопустимо. Повторите попытку.");
                    }

                    // intput ya
                    Console.WriteLine("Введите вещественное число - ординату точки A.");
                    while (true)
                    {
                        if (double.TryParse(Console.ReadLine(), out ya)) break;
                        Console.WriteLine("Введенное значение недопустимо. Повторите попытку.");
                    }

                    Console.WriteLine($"Точка A({xa}, {ya})");
                    Console.WriteLine($"Диаметр множества ДО добавления точки A: {points.Diametr:f3}");
                    points.AddPoint(xa, ya);
                    Console.WriteLine($"Диаметр множества ПОСЛЕ добавления точки A: {points.Diametr:f3}");
                }
                catch (ArgumentNullException e)
                {
                    Console.Write(e.Message);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}