/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self02
  Дата:      29.09.2023
*/

using System.Runtime.InteropServices;

namespace Self02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int n; // количество ступенек треугольника
                int m; // количество секций ёлочки

                Console.WriteLine("Введите N:");
                // вводим количество ступенек треугольника
                while (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите N:");
                }

                Console.WriteLine("Введите M:");
                // количество секций ёлочки
                while (!int.TryParse(Console.ReadLine(), out m))
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите M:");
                }

                Ornament(n, m);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static void Triagnle(int n)
        {
            if (n > 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Ornament(int n, int m)
        {
            if (m > 0)
            {
                for (int i = 0; i < m; i++)
                {
                    Triagnle(n);
                }
            }
            
        }
    }
}