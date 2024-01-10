namespace Task03Lib
{
    public interface IFigure
    {
        double Area { get; }
    }
    public class Square : IFigure
    {
        public double Side { get; set; }

        public Square(double side) { Side = side; }

        public double Area
        {
            get { return Side * Side; }
        }

        public override string ToString()
        {
            return $"Square with Side = {Side:f2}";
        }
    }
}