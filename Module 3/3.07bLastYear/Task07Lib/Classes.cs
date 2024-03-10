using System.Collections;

namespace Task07Lib
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public double Mod => Math.Sqrt(X * X + Y * Y);

        public bool Equals(Point other)
        => X == other.X && Y == other.Y;

        public override string ToString()
        => $"x = {X}, y = {Y}, mod = {Mod:G5}";
    }

    public class PointList : IEnumerable<Point>
    {
        private List<Point> list = new();
        public int Count { get { return list.Count; } }
        // Индексатор для класса PointList:
        public Point this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
        // Добавлять в список только новые точки:
        public void Add(Point point)
        {
            foreach (Point p in list)
                if (p.Equals(point)) return;
            list.Add(point);
        }

        // Реализуем члены интерфейсов:
        public IEnumerator<Point> GetEnumerator()
        {
            foreach(Point p in list) yield return p;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    } // PointList
}