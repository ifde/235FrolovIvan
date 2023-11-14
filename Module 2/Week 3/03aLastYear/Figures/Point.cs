namespace Figures
{
    public class Point
    {
        protected double _x, _y; // coordinates of the point

        /// <summary>
        /// Info about the figure
        /// </summary>
        /// <returns></returns>
        virtual public string Display()
        {
            return $"A point ({_x}, {_y})";
        }

        /// <summary>
        /// The area of the object
        /// </summary>
        virtual public double Area
        {
            get { return 0; }
        }
    }
}