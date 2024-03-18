using System.ComponentModel;
using Task02Lib;

namespace Task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.WhenAll(
                Task.Run(() => Dict.Add()),
                Task.Run(() => Dict.Add()),
                Task.Run(() => Dict.Add()),
                Task.Run(() => Dict.Add()),
                Task.Run(() => Dict.Add()));

            t.Wait();
            Console.WriteLine($"Total number of elements: {Dict.dict.Count}");
        }
    }
}