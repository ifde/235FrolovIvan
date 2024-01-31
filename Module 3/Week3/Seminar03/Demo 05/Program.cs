namespace Demo_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Methods.NewItemFilled += Methods.PrintSum;
            Methods.LineComplete += () => Console.WriteLine();
            int[,] arr = Methods.ArrayCreate();
            Methods.ArrayPrint(arr);
            

        }
    }

    public delegate void LineCompleteEvent();

    public class Methods
    {
        // статическое событие
        public static event LineCompleteEvent LineComplete;

        public static event Action<int[,]> NewItemFilled;

        public static void ArrayPrint(int[,] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                    Console.Write(arr[i, j] + " ");
                LineComplete(); // событие для перевода строки!
            }
        }

        public static int[,] ArrayCreate()
        {
            Random rnd = new Random();
            int[,] arr = new int[rnd.Next(1, 10), rnd.Next(1, 10)];
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    arr[i, j] = rnd.Next(1, 100);
                    NewItemFilled?.Invoke(arr);
                }
                    
            }
            return arr;
        }

        public static void PrintSum(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                    sum += arr[i, j];
            }
            Console.WriteLine(sum);

        }
    }

}