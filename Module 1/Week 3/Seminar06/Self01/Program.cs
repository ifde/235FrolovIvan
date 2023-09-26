/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      DIY01
   Дата:      26.09.2023
*/

namespace Self01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a\tb\tc\tЗначение выражения");

            // Перебираем значения a, b и c 
            for (uint a = 0; a <= 1; a++)
            {
                for (uint b = 0; b <= 1; b++)
                {
                    for (uint c = 0; c <= 1; c++)
                    {

                        Console.WriteLine($"{a}\t{b}\t{c}\t{!(ToBool(a) || ToBool(b) && ToBool(c)) || ToBool(a)}");
                    }
                }
            }

            static bool ToBool(uint n)
            {
                return n == 0 ? false : true;
            }
        }
    }
}