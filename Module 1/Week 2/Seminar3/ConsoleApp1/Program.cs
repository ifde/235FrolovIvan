/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self 01. Напишите программу на основе проекта консольного
            приложения. Вычислите и выведите на экран площадь
            правильного -угольника с длиной стороны
            (1 ≤ < 11, > 0). Для вычислений используйте формулу:
Дата:      16.09.2023
*/


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            double l;
            Console.WriteLine("Введите два числа: ");
            int.TryParse(Console.ReadLine(), out n);
            double.TryParse(Console.ReadLine(), out l);

            if (n >= 3)
            {
                Console.WriteLine(S(n, l));
            }
        }

        static double S (int n, double l)
        {
            return n * l * l / (4 * Math.Tan(Math.PI / n));
        }
    }
}