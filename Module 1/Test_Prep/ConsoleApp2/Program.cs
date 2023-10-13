/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2 Variation

Написать метод Summ( ) по вещественному параметру x и целому K вычисляющий значение суммы по следующему правилу:
	  
Значение бесконечной суммы вычислять с машинной точностью, в случае, если |x| < 7 из метода возвращать значение true и сумму, в противном случае false  и сумму.
Метод Print(a, b, X), выводит в консоль значение вещественных параметров a, b с точностью до четырёх знаков после десятичного разделителя в виде: Summ(<a>) = <b>.
Например, для параметров 1,12345 и 9,23432423 должно быть выведено: Summ(1,1235) = 9,2343.
В основной программе получить от пользователя целое K > 0. Затем, получив от пользователя вещественное значения x0 вычислять при помощи метода Summ( ) сумму ряда.  
\Если значение вычислена бесконечная сумма при помощи метода Print( ) выводить параметр x0 и её значение, 
в противном случае выводить значение K, затем с помощью метода Print( ) выводить x0 и значение суммы.
Предусмотреть повторение решения задачи без перезапуска. Методы класса System.Math не использовать.

 Дата:      13.10.2023
*/

using System.ComponentModel.Design;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int k;
                double x0;
                bool flag;

                Console.WriteLine("Введите целое число K > 0:");
                // вводим целое число K
                while (!int.TryParse(Console.ReadLine(), out k) || k <= 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите целое число K > 0:");
                }

                Console.WriteLine("Введите вещественное число X0:");
                // вводим вещественное число X0
                while (!double.TryParse(Console.ReadLine(), out x0))
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите вещественное число X0:");
                }

                double sum;
                (flag, sum) = Summ(x0, k);

                if (flag) Print(x0, sum);
                else
                {
                    Console.WriteLine($"K = {k}");
                    Print(x0, sum);
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Выводит в консоль значение вещественных параметров a, b с точностью до четырёх знаков после десятичного разделителя в виде: Summ(<a>) = <b>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Print(double a, double b)
        {
            Console.WriteLine($"Summ({a:f4}) = {b:f4}");
        }

        /// <summary>
        /// Вычисляет значение суммы по вещественному параметру X и целому K
        /// </summary>
        /// <param name="x"></param>
        /// <param name="k"></param>
        /// <returns>(true, sum) - if |x| is less than 7. (false, sum) otherwise </returns>
        static (bool, double) Summ(double x, int k)
        {
            if (x > -7 && x < 7)
            {
                int n = 1; // counter.
                double res1 = 0, // temporary sum. Initialized by the first element of the infinite sum (which is 0)
                    res; // sum
                double res_part1 = 1, // for calculating (x / 7)^n
                    res_part2 = 1; // for calculating n^2 / (n + 1)
                do
                {
                    res = res1;
                    res_part1 *= x / 7;
                    res_part2 *= (double)n / (n + 1) * n;
                    res1 += res_part1 * res_part2;
                } while (res != res1);

                return (true, res);
            }

            else
            {
                double res = 0; // the sum. Initialized by the first element of the infinite sum (which is 0)
                double res_part1 = 1, // for calculating (x / 7)^n
                    res_part2 = 1; // for calculating n^2 / (n + 1)
                for (int n = 1; n <= k; n++)
                {
                    res_part1 *= x / 7;
                    res_part2 *= (double)n / (n + 1) * n;
                    res += res_part1 * res_part2;
                }

                return (false, res);
            }
        }
    }
}