using System.Collections;

namespace Task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rainbow strings = new Rainbow();
            int i = 0;
            foreach (string color in strings)
            {
                if (++i % 3 == 0) break;
                Console.Write(color);
            }


            Console.WriteLine();

            foreach (string color in strings) Console.Write(color);
            Console.WriteLine();
        }
    }

    public class Rainbow
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "каждый ";
            yield return "охотник ";
            yield return "желает ";
            yield return "знать ";
            yield return "где ";
            yield return "сидит ";
            yield return "фазан ";
        }
    }
}