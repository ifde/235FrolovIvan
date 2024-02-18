
namespace Demo04Lib
{
    interface ITest<T>
    {
        int CompareTo(T other);
    }
    public class Point : IComparable<Point>
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        private double DistanceToZero => Math.Sqrt(X * X + Y * Y);

        public int CompareTo(Point? other)
        {
            if (other == null) throw new ArgumentNullException();
            return (int)(DistanceToZero - other.DistanceToZero);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public static bool operator >(Point point1, Point point2)
        {
            if (point1.DistanceToZero - point2.DistanceToZero < 0) return false;
            return true;
        }

        public static bool operator <(Point point1, Point point2)
        {
            return point2 > point1;
        }
    }

    public class Pair<T>
        where T : IComparable<T>
    {
        T t1, t2;
        public Pair(T t1, T t2)
        {
            if (t1.CompareTo(t2) > 0)
            {
                this.t1 = t2;
                this.t2 = t1;
            }
            else
            {
                this.t1 = t1;
                this.t2 = t2;
            }
        }

        public override string ToString()
        {
            return $"Pair: {t1}, {t2}";
        }
    }
}