/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      4 Variation

Метод SummCalculate() возвращает суммы S1 элементов стоящих на чётных (включая ноль) и 
S2 нечётных позициях в последовательности, заданной формулой:
R_0=1,R_n=-1/(n+1) ∑_(k=1)^n▒〖(n+1)!/(k+1)!(n-k)! R_(n-k) 〗
Общее количество элементов N – параметр метода.
Метод Print(a, b, c), выводит в консоль значение целого параметра a и 
вещественных параметров b, c с точностью до трёх знаков после десятичного разделителя 
в виде: <a>: S1=<b>, S2=<c>. Например, для параметров 5, 1,12345 и 9,23432423 должно быть выведено: 5: S1=1.123, S2=9,234.
В основной программе получить от пользователя целое значение N и, используя методы SummCalculate() и Print(), 
вывести на экран таблицу сумм элементов последовательности для всех целых чисел больше 0 и меньших N. 
После окончания формирования таблицы вывести информацию о номере под-последовательности, 
имеющей максимальную по модулю сумму всех элементов.


 Дата:      13.10.2023
*/

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // повтор решения 
            do
            {
                Console.Clear();

                int n;
                Console.WriteLine("Введите целое число N > 0:");
                // вводим целое число K
                while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите целое число N > 0:");
                }

                double sum1, sum2;

                (sum1, sum2) = SummCalculate(n);
                Print(n, sum1, sum2);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Выводит в консоль значение целого параметра a и вещественных параметров b, c 
        /// с точностью до трёх знаков после десятичного разделителяв виде: <a>: S1=<b>, S2=<c>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        static void Print(int a, double b, double c)
        {
            Console.WriteLine($"{a}: S1={b:f3}, S2={c:f3}");
        }

        /// <summary>
        /// возвращает суммы S1 элементов стоящих на чётных (включая ноль) и 
        /// S2 нечётных позициях в последовательности, заданной формулой: 
        /// R_0=1,R_n=-1/(n+1) ∑_(k= 1)^n▒〖(n+1)!/(k+1)!(n-k)! R_(n-k) 〗
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static (double, double) SummCalculate(int n)
        {
            double s1 = 1;
            double s2 = 0;
            double[] arr = new double[n];
            arr[0] = 1;

            for (int i = 1; i < n; i++)
            {
                double temp_sum = 0;
                for (int k = 1; k <= i; k++)
                {
                    temp_sum += FactDevision(i - k + 1, k + 1) * arr[i - k];
                }
                arr[i] = temp_sum;
                if (i % 2 == 0) s1 += temp_sum;
                else s2 += temp_sum;
            }
            return (s1, s2);
        }

        /// <summary>
        /// Calculating a! / b!
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static double FactDevision(int a, int b)
        {
            double res = 1;
            if (a >= b)
            {
                for (int i = 0; i < a - b; i++)
                {
                    res *= a--;
                }
                return res;
            }
            for (int i = 0; i < b - a; i++)
            {
                res /= b--;
            }
            return res;
        }
    }
}