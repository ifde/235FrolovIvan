namespace Self07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения
            do
            {
                Console.Clear();

                double x; // положительное вещественное число x
                uint n; // натуральное число n от 1 до 20

                // считываем x
                Console.WriteLine("Введите положительное вещественное число x:");
                while (!double.TryParse(Console.ReadLine(), out x) || x < 0)
                {
                    Console.WriteLine("Wrong input");
                    Console.WriteLine("Введите положительное вещественное число x:");
                }

                // считываем n
                Console.WriteLine("Введите натуральное число n от 1 до 20:");
                while (!uint.TryParse(Console.ReadLine(), out n) || n < 1 || n > 20)
                {
                    Console.WriteLine("Wrong input");
                    Console.WriteLine("Введите натуральное число n от 1 до 20:");
                }

                Console.WriteLine($"Полученное значение: {Formula(x, n):f3}");

                Console.WriteLine("\n----------------\nДля выхода из программы нажиме ESC.\nДля нового ввода - любую другую клавишу\n----------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Вычисление формулы
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static double Formula (double x, uint n)
        {
            double res = 0; // итоговое значение
            // вычисляем значение суммы в формуле
            for (uint k = 1; k <= n; k++)
            {
                res += Math.Abs(x - k) * Math.Cos(Math.Pow(k, 1 / 3) * x * 0.5);
            }
            res *= Math.Log(x) - 2.0 / 9;

            return res;
        }
    }
}