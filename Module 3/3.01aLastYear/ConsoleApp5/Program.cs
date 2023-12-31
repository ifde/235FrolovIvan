namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, double, double> f = (i, j, x) => i * x / j;

            Func<int, int, Func<int, double>, double> product = (int start, int finish, Func<int, double> f) =>
            {
                double res = 1;
                for (int j = start; j <= finish; j++)
                {
                    res *= f(j);
                }
                return res;
            };

            Func<int, int, Func<int, double>, double> sum = (int start, int finish, Func<int, double> f) =>
            {
                double res = 0;
                for (int i = start; i <= finish; i++)
                {
                    res += f(i);
                }
                return res;
            };

            Console.WriteLine("Введите вещественное значение x:");
            double x;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out x)) break;
                Console.WriteLine("Повторите попытку.");
            }

            double res = sum(1, 5, i => product(1, 5, j => f(i, j, x)));
            Console.WriteLine(res);

            res = 0;
            for (int i = 1; i <= 5; i++)
            {
                double prod = 1;
                for (int j = 1; j <= 5; j++)
                {
                    prod *= i * x / j;
                }
                res += prod;
            }
            Console.WriteLine(res);
        }

        static Func<int, int, double, double> GetFunc()
        {
            return (i, j, x) => i * x / j;
        }
    }
}