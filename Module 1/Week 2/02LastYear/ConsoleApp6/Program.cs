/*
  Дисциплина: "Программирование"
  Группа:      БПИ235(2)
  Студент:     Фролов Иван Григорьевич
  Задача:      Задача 7. Ввести трехзначное натуральное число и напечатать его цифры "столбиком".

    Дата:      15.09.2023
*/

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите трехзначное натуральное число: ");
            int.TryParse(Console.ReadLine(), out int a);
            a = (a < 0) ? -a : a;
            int one = a % 10;
            a /= 10;
            int two = a % 10;
            a /= 10;
            int three = a % 10;
            a /= 10;
            Console.WriteLine($"{three}\n{two}\n{one}");
        }

    }
}