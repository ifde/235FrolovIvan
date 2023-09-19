/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2
Дата:      17.09.2023
*/

using System.Diagnostics.SymbolStore;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool p, q;
            do
            {
                Console.Write("Введите p: ");
            } while (!bool.TryParse(Console.ReadLine(), out p));
            do
            {
                Console.Write("Введите q: ");
            } while (!bool.TryParse(Console.ReadLine(), out q));

            Console.WriteLine(Function1(p, q));
            Function2();
        }

        static bool Function1 (bool p, bool q)
        {
            return !(p && q) && ! (p | !q);
        }

        static void Function2 ()
        {
            string res = $"p\tq\t!(p & q) & !(p | !q)\n";
            res += $"{0}\t{0}\t{Function1(false, false)}\n";
            res += $"{0}\t{1}\t{Function1(false, true)}\n";
            res += $"{1}\t{0}\t{Function1(true, false)}\n";
            res += $"{1}\t{1}\t{Function1(true, true)}\n";

            Console.WriteLine(res);
        }
    }
}