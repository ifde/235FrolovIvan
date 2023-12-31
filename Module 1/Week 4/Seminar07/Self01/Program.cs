﻿/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self01
  Дата:      29.09.2023
*/

using System.Runtime.InteropServices;

namespace Self01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int n; // количетсво ступенек треугольника

                Console.WriteLine("Введите N:");
                while (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите N:");
                }

                Triagnle(n);

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
    }
}