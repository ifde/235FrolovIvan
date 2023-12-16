using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotClassLibrary
{
    /// <summary>
    /// Represents a set of points of a plain
    /// </summary>
    public class SetOfPoints
    {
        private Point[] points; // an array of Points

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">an array of point in the format "x;y"</param>
        public SetOfPoints(string[] data)
        {
            List<Point> temp = new List<Point>(); // list of points
            // filling temp
            foreach (string point in data)
            {
                string[] coordinates = point.Split(';');
                double x, y;
                if (double.TryParse(coordinates[0], out x) &&
                    double.TryParse(coordinates[1], out y))
                {
                    temp.Add(new Point(x, y));
                }
            }
            points = temp.ToArray();

        }
        /// <summary>
        /// Base constructor
        /// </summary>
        public SetOfPoints() : this(new string[] { "0;0" } ) { }
        /// <summary>
        /// Returs the diametr of the set of points
        /// </summary>
        public double Diametr
        {
            get { return CalculateDiametr(); }
        }

        /// <summary>
        /// Adds a new point to the set of points
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AddPoint(double x, double y)
        {
            Array.Resize(ref points, points.Length + 1);
            points[points.Length - 1] = new Point(x, y);
        }

        /// <summary>
        /// Calculates the diametr of the set of points
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private double CalculateDiametr()
        {
            
            if (points == null || points.Length == 0) throw new ArgumentNullException("Массив точек должен содержать минимум 2 объекта");
            if (points.Length == 1) { return 0; }

            double result = FindDistance(points[0], points[1]); // method output
            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    if (result > FindDistance(points[i], points[j])) result = FindDistance(points[i], points[j]);
                }
            }
            return result;
        }

        /// <summary>
        /// Find distance between two points
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        private double FindDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        public override string ToString()
        {
            string result = "";
            foreach (Point point in points)
            {
                result += point.ToString() + "\n";
            }
            return result;
        }
    }
}
