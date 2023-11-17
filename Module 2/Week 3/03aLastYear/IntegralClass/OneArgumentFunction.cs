namespace IntegralClass
{
    abstract public class OneArgumentFunction
    {

        /// <summary>
        /// A property for the left boundary of the integration
        /// </summary>
        public double Xmin
        {
            get;
            set;
        }

        /// <summary>
        /// A property for the right boundary of the integration
        /// </summary>
        public double Xmax
        {
            get;
            set;
        }

        /// <summary>
        /// Calculates the value of tthe function
        /// </summary>
        /// <returns></returns>
        abstract public double Function(double x);
    }
}