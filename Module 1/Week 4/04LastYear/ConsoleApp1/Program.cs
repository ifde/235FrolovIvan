/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      1
   Дата:      23.09.2023
*/


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint numb;
            Console.Write("Введите трехзначное число: ");

            if (uint.TryParse(Console.ReadLine(), out numb) && Transform(ref numb))
            {
                Console.WriteLine(numb);
            } 
            else
            {
                Console.WriteLine("Неверные данные");
            }


        }

        static bool Transform (ref uint numb)
        {
            if (numb.ToString().Length != 3)
            {
                return false;
            }
            uint a1 = numb % 10;
            numb /= 10;
            uint a2 = numb % 10;
            numb /= 10;
            uint a3 = numb % 10;
            numb /= 10;

            if (a1 > a2)
            {
                uint t = a1;
                a1 = a2;
                a2 = t;
            }
            if (a2 > a3)
            {
                uint t = a2;
                a2 = a3;
                a3 = t;
            }
            if (a1 > a2)
            {
                uint t = a1;
                a1 = a2;
                a2 = t;
            }

            numb = uint.Parse($"{a3}{a2}{a1}");

            return true;

        }
    }
}