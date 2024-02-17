using Demo04Lib;

namespace Demo04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);

            Pair<Point> pp = new Pair<Point>(point2, point1);
            Pair<Point> pp2 = new Pair<Point>(point1, point2);

            Console.WriteLine(pp);
            Console.WriteLine(pp2);
        }
    }
}