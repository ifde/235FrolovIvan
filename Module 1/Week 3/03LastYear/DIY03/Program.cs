/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      3 DIY
Дата:        22.09.2023
*/

namespace DIY03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            do
            {
                Console.Write("Введите натуральное x: ");
            } while (!double.TryParse(Console.ReadLine(), out x));

            do
            {
                Console.Write("Введите натуральное y: ");
            } while (!double.TryParse(Console.ReadLine(), out y));

            Console.WriteLine(F(x, y) ? "Точка попадает в сектор!" : "Точка не попадает в сектор!");
        }
        static bool F(double x, double y)
        {
            return x * x + y * y <= 4 && y <= x && x >= 0 ? true : false;
        }
    }

    
}