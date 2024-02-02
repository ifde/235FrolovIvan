namespace Functions
{
    public class Function
    {
        Func<double, double> f;

        public Function(Func<double, double> f)
        {
            this.f = f;
        }

        public Function() : this(x => x) { }

        public double GetValue(double x) => f(x); 
    }
}