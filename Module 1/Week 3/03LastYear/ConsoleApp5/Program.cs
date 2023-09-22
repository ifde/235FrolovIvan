/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      5
Дата:        22.09.2023
*/

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(F());
        }

        static double F ()
        {
            double res = 0;
            double i = 1;
            do
            {
                res += 1 / (i * (i + i) * (i + 2));
                i++;
            } while (i < 1000);
            return res;
        }
    }
}