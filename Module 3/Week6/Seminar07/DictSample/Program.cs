
namespace DictSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>()
            {
                [1] = "a",
                [2] = "b",
                [3] = "c"
            };

            foreach(int key in dict.Keys) Console.WriteLine(key);
            Console.WriteLine();
            foreach (string value in dict.Values) Console.WriteLine(value);
            Console.WriteLine();

            dict.Clear();
            dict[1] = "a1";
            dict[2] = "b2";
            dict[3] = "c3";

            foreach (int key in dict.Keys) Console.WriteLine($"({key} - {dict[key]})");
        }
    }
}