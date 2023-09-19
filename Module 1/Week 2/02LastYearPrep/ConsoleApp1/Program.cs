/*
  Дисциплина: "Программирование"
  Группа:      БПИ235(2)
  Студент:     Фролов Иван Григорьевич
  Задача:      1
    Дата:      15.09.2023
*/

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int cnt = 0;
            do
            {
                Console.WriteLine("Введите число: ");
                cnt += a > 0 && a % 2 == 0 ? 1 : 0;
            } while (!int.TryParse(Console.ReadLine(), out a) | a != 0);
            Console.WriteLine("Количество четнных чисел: " + cnt);
        }
    }
}
