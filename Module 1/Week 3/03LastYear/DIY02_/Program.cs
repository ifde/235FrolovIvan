/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2 DIY
Дата:        22.09.2023
*/

namespace DIY02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint a;
            do
            {
                Console.Write("Введите натуральное число a: ");
            } while (!uint.TryParse(Console.ReadLine(), out a) || a == 0);

            Console.WriteLine(F(a));

        }

        static string F(uint a)
        {
            string res = "";
            switch (a)
            {
                case 0:
                    return "0";
            }

            do
            {
                uint i = a % 10;
                a /= 10;
                res += i == 0 ? "" : i;
            } while (a != 0);

            return res;
        }
    }
}