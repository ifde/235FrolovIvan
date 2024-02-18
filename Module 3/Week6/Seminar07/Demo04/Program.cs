using Demo04Lib;

namespace Demo04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);

            Point[] points = new Point[10];
            Random rnd = new Random();
            Console.WriteLine("Initial array:");
            for (int i = 0; i < 10; i++)
            {
                points[i] = new Point(rnd.Next(10), rnd.Next(10));
                Console.WriteLine(points[i]);
            }
            Console.WriteLine();

            Array.Sort(points);

            Console.WriteLine("Sorted array:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(points[i]);
            }

            Pair<Point> pp = new Pair<Point>(point2, point1);
            Pair<Point> pp2 = new Pair<Point>(point1, point2);

            Console.WriteLine(pp);
            Console.WriteLine(pp2);
        }
    }
}