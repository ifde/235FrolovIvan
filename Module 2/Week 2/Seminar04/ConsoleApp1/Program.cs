/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self03
Дата:       27.11.2023
*/
using Lib_Shape;
using System;


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

                Random rnd = new Random();
                int n1 = rnd.Next(3, 6); // number of circles
                int n2 = rnd.Next(3, 6); // number of cylinders
                int n3 = rnd.Next(3, 6); // number of spheres
                Shape[] arr = new Shape[n1 + n2 + n3];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i < n1) arr[i] = new Circle(rnd.NextDouble() * 10);
                    else if (i < n2 + n1) arr[i] = new Cylinder(rnd.NextDouble() * 10, rnd.NextDouble() * 10);
                    else arr[i] = new Sphere(rnd.NextDouble() * 10);
                    if (arr[i] is Circle) Console.WriteLine("Circle. Area = " + arr[i].Area());
                    else Console.WriteLine(arr[i].AsString() + ". Area = " + arr[i].Area());
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}