using System.Diagnostics;
using Task01Lib;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Point<float>[] arr = new Point<float>[rnd.Next(1, 11)];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Point<float>((float)rnd.NextDouble(), (float)rnd.NextDouble());
            }
            foreach (Point<float> p in arr)
            {
                Console.WriteLine(p);
            }

            Array.Sort(arr);
            Console.WriteLine();

            foreach (Point<float> p in arr)
            {
                Console.WriteLine(p);
            }
            
        }

        static T Maximum<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
            //return a > b ? a : b;    //ERROR
        }

    }
}