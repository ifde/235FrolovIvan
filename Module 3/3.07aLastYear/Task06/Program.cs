using Task06Lib;

namespace Task06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileLines source = new FileLines(@"..\..\..\Program.cs");

            foreach (string item in source)
                Console.WriteLine(item);
            Console.WriteLine("*******************************************");

            foreach (string tem in source)
                Console.WriteLine(tem);

        }
    }
}