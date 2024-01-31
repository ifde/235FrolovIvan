using System.Collections.Immutable;
using System.Net.Http.Headers;

namespace Self01
{
    internal class Program
    {
        public static event Action<int[], int> SortEvent;
        static void Main(string[] args)
        {
            SortEvent += PrintCounter;
            Indicator indicator = new Indicator();
            SortEvent += indicator.PrintCurrentArr;

            Random rnd=  new Random();
            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++) arr[i] = rnd.Next(1, 11);

            Console.WriteLine("Initial array:");
            Console.WriteLine(string.Join(" ", arr) + '\n');

            Func<int, int, int> f = (a, b) => a - b; // increasing order

            Sort(arr, f);

        }

        static void PrintCounter(int[] arr, int cnt)
        {
            Console.WriteLine("Current number of permutatitons = " + cnt);
        }

        static void Sort(int[] arr, Func<int, int, int> f)
        {
            int cnt = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (f(arr[i], arr[j]) > 0)
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        cnt++;
                    }
                }
                SortEvent?.Invoke(arr, cnt);
            }
        }
    }

    public class Indicator
    {
        public void PrintCurrentArr(int[] arr, int cnt)
        {
            Console.WriteLine("Current array:\n" + string.Join(" ", arr) + '\n');
        }
    }
}