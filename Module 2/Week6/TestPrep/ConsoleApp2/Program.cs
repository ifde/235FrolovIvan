/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Вариант:     XXX
Дата:        16.12.23
*/
using ClassLibrary1;
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
                    Circle[] circles; // an array of circles
                    string[] data = File.ReadAllLines("input.txt");
                                                                                                                                             // for each point from the dots.txt file
                    Console.WriteLine("Считанные окружности:");
                    foreach (string line in data) { Console.WriteLine(line); }

                    List<Circle> temp = new List<Circle>();

                    foreach (string circle in data)
                    {
                        string[] values = circle[1..^1].Split(';');
                        double x, y, r;
                        if (double.TryParse(values[0], out x) &&
                            double.TryParse(values[1], out y) &&
                            double.TryParse(values[2], out r))
                        {
                            temp.Add(new Circle(new Point(x, y), r));
                        }
                    }
                    circles = temp.ToArray();

                    Console.WriteLine("До Сортировки:");
                    foreach(Circle circle in circles)
                    {
                        Console.WriteLine(circle);
                    }
                    Array.Sort(circles); // sorting

                    Console.WriteLine("После Сортировки:");
                    
                    foreach (Circle circle in circles)
                    {
                        Console.WriteLine(circle);
                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("Ошибка при чтении файла.");
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