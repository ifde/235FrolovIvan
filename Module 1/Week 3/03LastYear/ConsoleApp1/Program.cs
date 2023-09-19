/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1
Дата:      17.09.2023
*/

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a;
            do
            {
                Console.Write("Введите число a: ");
            } while (!int.TryParse(Console.ReadLine(), out a));
            Console.WriteLine(F(a));
        }

        static string F (int a)
        {
            return a switch
            {
                1 or 2 or 3 => "Неудовлетворительно",
                4 or 5 => "Удовлетворительно",
                6 or 7 => " Хорошо",
                8 or 9 or 10 => "Отлично",
                _ => "Неверные входные данные"
            };
        }
    }
}