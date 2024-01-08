namespace Task01Lib
{
    public class Point<T> : IComparable<Point<T>>
        where T : notnull
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Point(T x, T y) {  X = x; Y = y; }

        public int CompareTo(Point<T>? p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
            return Math.Sqrt((dynamic)X * (dynamic)X + (dynamic)Y * (dynamic)Y) - 
                Math.Sqrt((dynamic)p.X * (dynamic)p.X + (dynamic)p.Y * (dynamic)p.Y) > 0 ? 1 : -1;
        }

        public override string ToString()
        {
            return $"({X:f3}, {Y:f3})";
        }
    }
}