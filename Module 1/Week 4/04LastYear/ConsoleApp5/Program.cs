/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      5
   Дата:      23.09.2023
*/


namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint n;
            do
            {
                Console.Write("Введите n: ");
            } while (!uint.TryParse(Console.ReadLine(), out n));

            S(n);

        }

        static void S(uint n)
        {
            for (int k = 0; k <= n; k++)
            {
                Console.WriteLine($"k = {k}:\t{(k + 0.3) / (3 * k * k + 5)}");
            }
        }
    }
}