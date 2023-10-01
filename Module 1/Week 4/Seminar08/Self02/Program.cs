/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      Self02
   Дата:     30.09.2023
*/

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
                double a, b, c; // стороны треугольника
                double p, // периметр треугольника
                    s; // площадь треугольника 

                // ввод данных
                bool flag = false; // флаг, чтобы при первом вводе данных не выводилось сообщение (1)
                do
                {
                    if (flag)
                    {
                        Console.WriteLine("Треугольника с такими сторонами не существует. Повторите ввод.\n"); // сообщение (1)
                    }
                    flag = true;

                    // вводим сторону a
                    Console.WriteLine("Введите длину стороны a:");
                    while (!double.TryParse(Console.ReadLine(), out a) || a <= 0)
                    {
                        Console.WriteLine("Неверное значение. Повторите ввод");
                        Console.WriteLine("Введите длину стороны a:");
                    }

                    // вводим сторону b
                    Console.WriteLine("Введите длину стороны b:");
                    while (!double.TryParse(Console.ReadLine(), out b) || b <= 0)
                    {
                        Console.WriteLine("Неверное значение. Повторите ввод");
                        Console.WriteLine("Введите длину стороны b:");
                    }

                    // вводим сторону c
                    Console.WriteLine("Введите длину стороны c:");
                    while (!double.TryParse(Console.ReadLine(), out c) || c <= 0)
                    {
                        Console.WriteLine("Неверное значение. Повторите ввод");
                        Console.WriteLine("Введите длину стороны c:");
                    }
                } while (!Triangle(a, b, c, out p, out s));

                Console.WriteLine($"Периметр треугольника равен {p}");
                Console.WriteLine($"Площадь треугольника равна {s}");

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Вычисление площади и периметра треугольника по заданным длинам сторон
        /// </summary>
        /// <returns></returns>
        public static bool Triangle(double x, double y, double z, out double p, out double s)
        {
            if (x + y <= z || x + z <= y || z + y <= x)
            {
                p = s = -1;
                return false;
            }
            p = x + y + z;
            s = Math.Sqrt(p / 2 * (p / 2 - x) * (p / 2 - y) * (p / 2 - z));
            return true;
        }
    }
}