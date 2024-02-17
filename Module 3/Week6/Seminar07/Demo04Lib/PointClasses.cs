
namespace Demo04Lib
{
    interface ITest<T>
    {
        int CompareTo(T other);
    }
    public class Point: IComparable<Point>
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        private double DistanceToZero()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public int CompareTo(Point? other)
        {
            if (other == null) throw new ArgumentNullException();
            return (int)(DistanceToZero() - other.DistanceToZero());
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public class Pair<T>
        where T: IComparable<T>
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