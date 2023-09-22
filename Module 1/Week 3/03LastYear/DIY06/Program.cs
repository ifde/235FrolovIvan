/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      6 DIY
Дата:        22.09.2023
*/

namespace DIY06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint a, b, c;
            do
            {
                Console.Write("Введите a: ");
            } while (!uint.TryParse(Console.ReadLine(), out a) || ! (a >= 100 && a <= 999));

            do
            {
                Console.Write("Введите b: ");
            } while (!uint.TryParse(Console.ReadLine(), out b) || !(b >= 100 && b <= 999));

            do
            {
                Console.Write("Введите c: ");
            } while (!uint.TryParse(Console.ReadLine(), out c) || !(c >= 100 && c <= 999));

            Console.WriteLine($"Аудитория с минимальным номером внутри этажа: {F(a, b, c)}");
        }

        static uint F (uint a, uint b, uint c)
        {
            uint a1 = a % 100, b1 = b % 100, c1 = c % 100;
            return a1 < b1 ? (a1 > c1 ? c : a) : (b1 > c1 ? c : b);
        }
    }
}