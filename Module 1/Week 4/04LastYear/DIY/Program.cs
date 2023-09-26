/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      DIY01
   Дата:      26.09.2023
*/

namespace DIY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Все тройки попарно различных чисел, таких что\na * a + b * b = c * c");
            // перебираем возможные значения переменных a, b и c
            for (uint a = 1; a <= 20; a++)
            {
                for (uint b = 1; b <= 20; b++)
                {
                    for (uint c = 1; c <= 20; c++)
                    {
                        if (a * a + b * b == c * c && a != b && b != c && a != c)
                        {
                            Console.WriteLine($"{a} * {a} + {b} * {b} = {c} * {c}");
                        }
                    }
                }
            }

        }
    }
}