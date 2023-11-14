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

        }
    }
}