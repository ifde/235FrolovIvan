/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Вариант:      62
  Дата:      28.09.2023
*/

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

                double x; // real number x

                Console.WriteLine("Комментарий: Если x по модулю больше примерно 0,39 - то происходит переполнение типа double.\n Чтобы программа работала корректно, такие значения вводить не стоит.\n");
                Console.WriteLine("Введите вещественное число x:");
                // input x
                while (!double.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите вещественное число x:");
                }

                Console.WriteLine($"Значение функции: {Func(x):f6}");
                Console.WriteLine($"Контрольное значение: {Math.Sin(x) - Math.Cos(x) + 1:f6}");

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Calculating the sum of an infinite series
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static double Func(double x)
        {
            double res, // final value
                res1 = 0; // temporary value
            int k = 1; // counter
            int fact = 1 * 2; // factorial used in the fromula; uptades each iteration
            do
            {
                res = res1;
                res1 += ((2 * k - 1) % 4 == 3 ? -1 : 1) * Math.Pow(x, 2 * k - 1) / fact * (2 * k + x);
                fact *= (2 + k + 1) * (2 * k + 2);
                k++;
            } while (Math.Abs(res1 - res) > double.Epsilon); // accurate to epsilon

            return res;
        }
    }
}