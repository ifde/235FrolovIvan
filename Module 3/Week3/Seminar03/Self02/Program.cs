using Self02Lib;

namespace Self02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            Console.WriteLine("Input Double X:");
            while(true)
            {
                if (double.TryParse(Console.ReadLine(), out x)) break;
                Console.WriteLine("Wrong input. Try again.");
            }

            Console.WriteLine("Input Double Y:");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out y)) break;
                Console.WriteLine("Wrong input. Try again.");
            }

            Dot D = new Dot(x, y);
            D.OnCoordChanged += PrintInfo;
            D.DotFlow(); 
        }

        static void PrintInfo(Dot A)
        {
            Console.WriteLine($"({A.X:f2}, {A.Y:f2})");
        }
    }
}