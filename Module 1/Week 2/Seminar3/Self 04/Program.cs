/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self 04. Задание 4.
Дата:      16.09.2023
*/

namespace Self_04
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
            Console.WriteLine(F(x, y));

        }

        static double F (double x, double y)
        {
            if (x < y)
            {
                return Math.Sin(x) + Math.Pow(Math.Cos(y), 2);
            } 
            if (x == y)
            {
                return Math.Log10(x);
            } 
            return Math.Cos(x) + Math.Pow(Math.Sin(y), 2);
        }
    }
}