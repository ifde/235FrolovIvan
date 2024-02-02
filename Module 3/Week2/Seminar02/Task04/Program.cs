namespace Task04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> f = x => x;
            Action<int> g = (x) => Console.WriteLine(x);

            // A delegate for calculating sum
            Func<int, int, Func<int, double>, double> sum = delegate (int start, int end, Func<int, double>  f)
            {
                double res = 0;
                for (int i = start; i <= end; i++)
                {
                    res += f(i);
                }
                return res;
            };

            // A delegate for calculating multiplication
            Func<int, int, Func<int, double>, double> mult = delegate (int start, int end, Func<int, double> f)
            {
                double res = 1;
                for (int i = start; i <= end; i++)
                {
                    res *= f(i);
                }
                return res;
            };

            Console.WriteLine("Введите вещественное число x:");
            double x;
            double.TryParse(Console.ReadLine(), out x);
            double res = sum(1, 5, (i) => i * mult(1, 5, (j) => x / j));
            Console.WriteLine("Вычисленное выражение:\n" + res);

        }
    }
}