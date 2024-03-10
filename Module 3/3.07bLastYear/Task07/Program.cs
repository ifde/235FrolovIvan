using Task07Lib;

namespace Task07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PointList set = new PointList();
            set.Add(new Point(4, 5));
            set.Add(new Point(4, 5));
            set.Add(new Point(4, 5));
            set.Add(new Point(7, 1));
            set.Add(new Point(7, 2));
            set.Add(new Point(5, 2));
            set.Add(new Point(7, 2));
            Console.WriteLine("Список точек на плоскости:");
            foreach (Point p in set)
                Console.WriteLine(p.ToString());

            // Обработка списка в LINQ-запросах:
            IEnumerable<Point> newList =
                from v in set
                orderby v.Mod
                select v;

            Console.WriteLine("Список упорядоченных точек:");
            foreach (Point p in newList)
                Console.WriteLine(p.ToString());

            var res = from r in set
                      where r.Mod > 7
                      select r;
            //Console.WriteLine(res.GetType());
            Console.WriteLine("Список точек c модулем большим 7:");
            foreach (Point p in res)
                Console.WriteLine(p.ToString());


        }
    }
}