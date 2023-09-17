/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      Self 03.
   Дата:      16.09.2023
*/

namespace Self03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Введите код операции: ");
            } while (!int.TryParse(Console.ReadLine(), out n));

            double a, b;
            do
            {
                Console.Write("Введите A: ");
            } while (!double.TryParse(Console.ReadLine(), out a));

            do
            {
                Console.Write("Введите B: ");
            } while (!double.TryParse(Console.ReadLine(), out b));

            if (n == 1)
            {
                Console.WriteLine(a + b);
            }
            else if (n == 2)
            {
                Console.WriteLine(a - b);
            }
            else if (n == 3)
            {
                Console.WriteLine(a * b);
            }
            else if (n == 4)
            {
                if (b == 0)
                {
                    Console.WriteLine("Ошибка");
                }
                else
                {
                    Console.WriteLine(a / b);
                }
                
            }
            else
            {
                Console.WriteLine("Ошибка");
            }

        }
    }
}