namespace Task02
{
    internal class Program
    {
        public static uint FigSum(uint k)
        {
            if (k / 10 == 0) return k;
            return FigSum(k / 10) + k % 10;
        }
        static void PrintSeries<T>(IEnumerable<T> ser)
        {
            var line = ser.Select(x => x.ToString());
            Console.WriteLine(Enumerable.Aggregate(line, (x, y) => x + "\t" + y));
        }
        static void Main(string[] args)
        {
            uint[] row = { 543, 67, 234, 765 };
            Console.WriteLine("Исходный массив:");
            PrintSeries(row);
            Console.WriteLine("Суммы цифр элементов массива: ");
            var series = row.Select(x => FigSum(x));
            PrintSeries(series);
            var res = series.Sum(x => x);
            Console.WriteLine("Общая сумма цифр = " + res);
        }
    }
}