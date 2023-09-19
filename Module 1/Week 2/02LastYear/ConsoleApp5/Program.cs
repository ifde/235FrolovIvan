/*
  Дисциплина: "Программирование"
  Группа:      БПИ235(2)
  Студент:     Фролов Иван Григорьевич
  Задача:      Задача 5. Задан круг с центром в начале координат и радиусом R=10.   
                Ввести  координаты точки и вывести сообщение:   «Точка внутри круга!» или «Точка вне круга!».

                Предусмотреть проверку входных данных и цикл повторения решений.

    Дата:      15.09.2023
*/

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            do
            {
                Console.WriteLine("Введите x:");
            } while (!double.TryParse(Console.ReadLine(), out x));

            do
            {
                Console.WriteLine("Введите y:");
            } while (!double.TryParse(Console.ReadLine(), out y));
            Console.WriteLine(InCircle(x, y));

        }

        static string InCircle (double x, double y)
        {
            double r = 10;
            return x * x + y * y <= r * r ? "Точка внутри круга!" : "Точка вне круга!";
        }
    }
}