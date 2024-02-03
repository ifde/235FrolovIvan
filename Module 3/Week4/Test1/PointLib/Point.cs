namespace PointLib
{
    public interface INearFunc
    {
        bool IsNearFunc(Func<double, double> f, double eps);
    }
    public class Point : INearFunc
    {
        double x, y; // the coordinates of the point

        public double X { get { return x; } }
        public double Y { get { return y; } }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point() : this(0, 0) { }

        public bool IsNearFunc(Func<double, double> f, double eps)
        {
            if (f == null) throw new ArgumentNullException(nameof(f));
            return f(x) >= f(x - eps) && f(x) <= f(x + eps);
        }

    }
}