/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      Self03
   Дата:      24.09.2023
*/

namespace Self03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                double a; // Граница площадки [0:a]
                uint n; // количество разбиений
                        // Вводим a
                do
                {
                    Console.Write("Введите число A: ");
                } while (!double.TryParse(Console.ReadLine(), out a) || a < 0);

                // Вводим n
                do
                {
                    Console.Write("Введите число отрезков разбиения: ");
                } while (!uint.TryParse(Console.ReadLine(), out n) || n == 0);

                Console.WriteLine($"Искомая площадь равна {Area(a, n):f3}");

                Console.WriteLine("Для завершения программы нажмите ESC");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            
        }

        /// <summary>
        /// f(x) = x * x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static double F(double x)
        {
            return x * x;
        }

        /// <summary>
        /// Считаем площадь под параболой
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static double Area(double a, uint n)
        {
            double eps = a / n; // длина отрезка разбиения
            double x1 = 0, x2 = x1 + eps; // границы текущего отрезка 
            double s = 0; // Area
            do
            {
                s += eps * 0.5 * (F(x1) + F(x2));
                x1 = x2;
                x2 = x1 + eps;
            } while (x2 <= a);

            s += 0.5 * (a - eps) * (F(x1) + F(a));

            return s;
        }
    }
}