using Task4Lib;

namespace ConsoleApp4
{
    delegate int DecreasingOrder(int a, int b);
    internal class Program
    {
        static void Main(string[] args)
        {
            Series arr = new Series(new int[] { 1, 2, 3, 6, 5, 7, 0, 9, 8 });
            DecreasingOrder decOrd = (a, b) => b - a;

            Console.WriteLine("Исходный массив:");
            PrintArr(arr);

            Console.WriteLine("Сортировка по возрастанию:");
            arr.Order(IncreasingOrder);
            PrintArr(arr);

            Console.WriteLine("Сортировка по убыванию:");
            arr.Order((a, b) => b - a);
            PrintArr(arr);

            Console.WriteLine("Сортировка по четности (сначала - четные, потом - нечетные):");
            arr.Order((a, b) => a % 2 - b % 2);
            PrintArr(arr);

        }

        public static int IncreasingOrder (int a, int b)
        {
            return a - b;
        }

        public static void PrintArr(Series arr)
        {
            Console.WriteLine(string.Join(" ", arr.Arr));
        }
    }
}