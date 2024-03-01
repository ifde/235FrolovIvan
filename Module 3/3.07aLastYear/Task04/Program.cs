using System.Net.Http.Headers;
using Task04Lib;

namespace Task04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Evens ev = new Evens(1, 25);
            Primes pr = new Primes(-100, 100);
            foreach (int item in ev) Console.Write(item + " ");
            Console.WriteLine();
            foreach (int item in pr) Console.Write(item + " ");
            Console.WriteLine();
        }
    }
}