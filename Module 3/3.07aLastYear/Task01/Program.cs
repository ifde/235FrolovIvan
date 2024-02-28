using System.Collections;

namespace Task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            foreach (string str in a)
                Console.WriteLine(str);

        }
    }

    public class A : IEnumerable<string>
    {
        private string[] arr = { "раз ромашка ", "два ромашка ",
                                 "три ромашка ", "пять ромашка ", "шесть ромашка " };

        public IEnumerator<string> GetEnumerator()
        {
            foreach (string str in arr)
            {
                yield return str;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    } //end of A

}