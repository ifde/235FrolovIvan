using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Circle : Point
    {
        private double _rad; // the radius of the circle

        public Circle(int x, int y, int rad)
        {
            _x = x;
            _y = y;
            _rad = rad;
        }

        /// <summary>
        /// Gets the radius of the circle
        /// </summary>
        public double Rad { get { return _rad;} }

        override public string Display()
        {
            return $"A circle with the center in ({_x}, {_y}) and raduis {_rad}";
        }

        override public double Area
        {
            get { return Math.PI * _rad * _rad; }
        }

        /// <summary>
        /// Get the legnth of the circle
        /// </summary>
        override public double Len
        {
            get { return 2 * Math.PI * _rad; }
        }
    }
}
