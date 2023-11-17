/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      6
 Дата:       17.11.2023
*/

using IntegralClass;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fun_1 f1 = new Fun_1(-1, 2);
            Console.WriteLine("Интеграл_1 = {0:g6}", CalculateIntegral(f1, 20));
            Console.WriteLine("Интеграл_2 = {0:g6}",
                                       CalculateIntegral(new Fun_2(0, 0.5), 20));
            Console.WriteLine("Интеграл_2 = {0:g6}",
                                       CalculateIntegral(new Fun_3(-1, 1), 20));

        }

        /// <summary>
        /// Calculates Integral
        /// </summary>
        /// <param name="f"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double CalculateIntegral(OneArgumentFunction f, int n)
        {
            if (n <= 0) throw new ArgumentException("Неверно указано число шагов");
            double h = (f.Xmax - f.Xmin) / n; // a step
            double s = 0; // method output
            double x1 = f.Xmin;
            double x2 = f.Xmin + h;
            for (int i = 0; i < n; i++)
            {
                s += 0.5 * h * (f.Function(x1) + f.Function(x2));
                x1 = x2;
                x2 += h;
            }
            return s;
        }
    }
}