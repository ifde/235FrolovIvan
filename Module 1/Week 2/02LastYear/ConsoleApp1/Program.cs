/*
  Дисциплина: "Программирование"
  Группа:      БПИ235(2)
  Студент:     Фролов Иван Григорьевич
  Задача:      Задача 1. Написать метод для вычисления приближенного значения n-го члена ряда Фибоначчи по формуле Бине
    Дата:      15.09.2023
*/


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            do { 
                Console.WriteLine("Введите натуральное число: ");
            } while (!int.TryParse(Console.ReadLine(), out n));
            Console.WriteLine("Ответ: " + Bine(n));
        }

        static double Bine (int n)
        {
            double b = (1 + Math.Pow(5, 0.5)) / 2;
            return (Math.Pow(b, n) - Math.Pow(-b, -n)) / (2 * b - 1);
        }
    }
}