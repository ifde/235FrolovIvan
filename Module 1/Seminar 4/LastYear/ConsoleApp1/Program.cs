namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! \a");
            Console.WriteLine("ab\bc");
            Console.WriteLine(3 & 4);
            Console.WriteLine(-127);

            const byte x = 12, y = 10;
            int z = 12;
            sbyte a = (sbyte)(z & y);
            sbyte t = -12;
            uint t1 = (uint)t;
            Console.WriteLine(t1);
        }
    }
}