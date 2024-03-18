using System.Collections.Concurrent;

namespace Task02Lib
{
    public class Dict
    {
        private const int RUNS = 1000;

        public static readonly ConcurrentDictionary<int, int> dict = new ConcurrentDictionary<int, int>();

        public static void Add()
        {
            for (int i = 0; i < RUNS; i++)
            {
                if (dict.TryAdd(i, i))
                {
                    Console.WriteLine($"{i} was added");
                }
            }
        }
    }
}