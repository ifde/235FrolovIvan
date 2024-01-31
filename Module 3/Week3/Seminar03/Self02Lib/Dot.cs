namespace Self02Lib
{
    public delegate void CoordChanged(Dot dot);
    public class Dot
    {
        public event CoordChanged OnCoordChanged;
        public double X { get; set; }
        public double Y { get; set; }

        public Dot() { X = 0; Y = 0; }
        public Dot(double x, double y) {  X = x; Y = y; }

        public void DotFlow()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                X = rnd.NextDouble() * 20 - 10;
                Y = rnd.NextDouble() * 20 - 10;
                if (X < 0 && Y < 0) OnCoordChanged(this);
            }
        }

    }
}