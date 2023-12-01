/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Вариант:     XXX 
Дата:        2.12.2023
*/


using System.Diagnostics;
using Figures;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // repeat program
            do
            {
                Console.Clear();

                int m, n;
                Shape3D[] shapes;

                // input n
                Console.WriteLine("Введите натуральное число n. 0 < n < 10");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out n) && n > 0 && n < 10) break;
                    Console.WriteLine("Введено неверное значение. Повторите попытку.");

                }

                // input m
                Console.WriteLine("Введите натуральное число m. 0 < m < 10");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out m) && m > 0 && m < 10) break;
                    Console.WriteLine("Введено неверное значение. Повторите попытку.");

                }

                shapes = new Shape3D[n + m];
                // filling shapes[] with objects
                for (int i = 0; i < shapes.Length; i++)
                {
                    if (i < n) 
                    {
                        shapes[i] = new Cube();
                        Console.WriteLine($"Cube. {shapes[i]}. Area = {shapes[i].S():f3}. Volume = {shapes[i].V():f3}");
                    }

                    else if (i < m + n) 
                    {
                        shapes[i] = new Sphere();
                        Console.WriteLine($"Sphere. {shapes[i]}. Area = {shapes[i].S():f3}. Volume = {shapes[i].V():f3}");
                    }
                    
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}