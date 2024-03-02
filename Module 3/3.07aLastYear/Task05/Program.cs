using Task05Lib;

namespace Task05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            MyIterator<int> collect_3 = new MyIterator<int>(values, 3);
            foreach (object ob in collect_3)
                Console.Write(ob + "  ");
            Console.WriteLine();
            foreach (int ob in new MyIterator<int>(values, 1))
                Console.Write(ob + "  ");
            Console.WriteLine();
            foreach (int ob in new BFIterator<int>(values))
                Console.Write(ob + "  ");
            Console.WriteLine();
            Console.WriteLine("\nНажмите ENTER. . . ");
            Console.ReadLine();
        }
    }
}