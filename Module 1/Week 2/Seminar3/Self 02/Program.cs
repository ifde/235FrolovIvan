/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self 02. Попадание точки в область
Дата:      16.09.2023
*/

namespace Self_02_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            Console.WriteLine("Введите x: ");
            double.TryParse(Console.ReadLine(), out x);
            Console.WriteLine("Введите y: ");
            double.TryParse(Console.ReadLine(), out y);

            Console.WriteLine(InArea(x, y));
        }

        static string InArea(double x, double y)
        {
            bool a = y >= 0 && x * x + y * y > 1;
            bool b = y >= 0 && x * x + y * y < 4;
            if (a && b)
            {
                return "Точка в области";
            }
            if (y >= 0 && (x * x + y * y == 1 || x * x + y * y == 4 || (y == 0 && (x >= -2 && x <= -1 || x >= 1 && x <= 2))))
            {
                return "Точка на границе";
            }
            return "Точка не принадлежит области";
        }
    }
}