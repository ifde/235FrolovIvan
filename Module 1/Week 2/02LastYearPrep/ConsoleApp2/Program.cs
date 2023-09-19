/*
  Дисциплина: "Программирование"
  Группа:      БПИ235(2)
  Студент:     Фролов Иван Григорьевич
  Задача:      2
    Дата:      15.09.2023
*/

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            do
            {
                Console.WriteLine("Введите число: ");
            } while (!int.TryParse(Console.ReadLine(), out a));
            Console.WriteLine("Результат: " + a / 100 % 10);
        }
    }
}
