/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      Self 01.
   Дата:      16.09.2023
*/

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a;
            char.TryParse(Console.ReadLine(), out a);
            Console.WriteLine(a);

            switch (a)
            {
                case >= '0' and <= '9':
                    Console.WriteLine(100);
                    break;
                case >= 'A' and <= 'Z':
                    Console.WriteLine(200);
                    break;
                case >= 'a' and <= 'z':
                    Console.WriteLine(300);
                    break;
                default:
                    Console.WriteLine(400);
                    break;

            }
        }
    }
}