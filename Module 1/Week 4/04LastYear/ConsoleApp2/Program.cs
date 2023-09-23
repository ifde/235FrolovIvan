/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      2
   Дата:      23.09.2023
*/

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a;
            do
            {
                Console.Write("Введите символ латинского алфавита: ");
            } while (!char.TryParse(Console.ReadLine(), out a));

            Console.WriteLine(F(ref a) ? a : "Неверные входные данные");
        }


        static bool F(ref char a)
        {
            int alp = 'z' - 'a' + 1;
            if (!(a >= 'a' && a <= 'z'))
            {
                return false;
            }
            if (a <= 'd') {
                a = (char)(a - 4 + alp);
            } 
            else
            {
                a = (char)(a - 4);
            }
            return true;
        }
    }
}