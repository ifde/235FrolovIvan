namespace Task03NewLib
{
    public interface IFigure
    {
        double Area { get; } 
    }
    public class Square : IFigure
    {
        double a;
        public Square(double a)
        {
            this.a = a;
        }
        public Square() : this(0) { }

        public double Area => a * a;

        public override string ToString()
        {
            return $"Square. A = {a}";
        }
    }

    public class Circle : IFigure
    {
        double r;
        public Circle(double r)
        {
            this.r = r;
        }
        public Circle() : this(0) { }

        public double Area => r * r * Math.PI;

        public override string ToString()
        {
            return $"Circle. R = {r}";
        }
    }
}