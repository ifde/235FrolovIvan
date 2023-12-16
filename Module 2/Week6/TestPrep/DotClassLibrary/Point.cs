namespace DotClassLibrary
{
    /// <summary>
    /// Represent a point on a plane
    /// </summary>
    public class Point
    {
        public double X {  get; set; } // x-coordinate 
        public double Y { get; set; } // y-coordinates

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y) {  X = x; Y = y; }
        /// <summary>
        /// Base constructor
        /// </summary>
        public Point() : this(0, 0) { }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}