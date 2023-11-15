/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2
 Дата:      14.11.2023
*/

using Figures;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point();
            p.Display();
            Console.WriteLine("p.Area для Point = " + p.Area);
            p = new Circle(1, 2, 6);
            p.Display();
            Console.WriteLine("p.Area для Circle = " + p.Area);
            p = new Square(3, 5, 8);
            p.Display();
            Console.WriteLine("p.Area для Square = " + p.Area);
            Console.WriteLine(Environment.NewLine);

            int circleNum; // the number of Circle objects
            int squareNum; // the number of Square objects
            Point[] arr = FigArray(out circleNum, out squareNum);

            Console.WriteLine("Количество объектов типа Circle: " + circleNum);
            Console.WriteLine("Количество объектов типа Square: " + squareNum);

            foreach (Point elem in  arr)
            {
                if (elem is Circle) Console.WriteLine($"Объект Circle. Площадь = {elem.Area:f3}. Периметр = {elem.Len:f3}");
                else Console.WriteLine($"Объект Square. Площадь = {elem.Area:f3}. Периметр = {elem.Len:f3}");

            }

        }

        static Point[] FigArray(out int circleNum, out int squareNum)
        {
            Random rnd = new Random();
            circleNum = rnd.Next(11); // the number of Circle objects
            squareNum = rnd.Next(11); // the number of Square objects

            Point[] points = new Point[circleNum + squareNum]; // method output

            for (int i = 0; i <  circleNum; i++)
            {
                points[i] = new Circle(rnd.Next(10, 100), rnd.Next(10, 100), rnd.Next(10, 100));
            }

            for (int i = circleNum; i < circleNum + squareNum; i++)
            {
                points[i] = new Square(rnd.Next(10, 100), rnd.Next(10, 100), rnd.Next(10, 100));
            }

            return points;
        }
    }
}