namespace ConsoleApp5
{
    public delegate void LineCompleteEvent();

    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,] arr = new int[rnd.Next(1, 11), rnd.Next(1, 11)];
            int sum = 0;

            Methods.NewItemFilled += (int i) => sum += i;
            Methods.FillArray(arr);

            Methods.LineComplete += () => Console.WriteLine();
            Methods.ArrayPrint(arr);

            Console.WriteLine($"The sum of the elements of the array is {sum}");

        }
    }

    public class Methods
    {
        // статическое событие
        public static event LineCompleteEvent LineComplete;
        public static event Action<int> NewItemFilled; 

        public static void ArrayPrint(int[,] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                    Console.Write(arr[i, j] + " ");
                LineComplete?.Invoke(); // событие для перевода строки!
            }
        }

        public static void FillArray(int[,] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    arr[i, j] = rnd.Next(1, 11);
                    NewItemFilled?.Invoke(arr[i, j]);
                }
                    
            }
        }
    }

}