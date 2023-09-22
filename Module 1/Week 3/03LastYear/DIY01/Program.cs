/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1 DIY
Дата:        22.09.2023
*/


namespace DIY01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            F ();
        }

        static uint F ()
        {
            uint s = 0, i = 0;
            do
            {
                i++;
                s += i;
            } while (s < 111 || !(s % 10 == s / 10 % 10 && s / 10 % 10 == s / 100));
            Console.WriteLine(s);
            Console.WriteLine(i);
            Console.WriteLine($"1 + 2 + 3 + ... + {i - 2} + {i - 1} + {i}");
            return s;
        }
    }
}