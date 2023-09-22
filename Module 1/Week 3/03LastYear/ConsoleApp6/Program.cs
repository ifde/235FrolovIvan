/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      6
Дата:        22.09.2023
*/

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double k, r;
            uint n;
            do
            {
                Console.Write("Ввведите начальный капитал: ");
            } while (!double.TryParse(Console.ReadLine(), out k) || k < 0);

            do
            {
                Console.Write("Ввведите процентную ставку: ");
            } while (!double.TryParse(Console.ReadLine(), out r) || r < 0);

            do
            {
                Console.Write("Ввведите число лет: ");
            } while (!uint.TryParse(Console.ReadLine(), out n) || n == 0);

            Total(k, r, n);

        }
        static double Total(double k, double r, uint n)
        {
            int i = 0;
            do
            {
                i++;
                k *= (1 + r / 100);
                Console.WriteLine($"Год {i}:\t{k}");
            } while (i < n);

            return k;
        }

    }
}