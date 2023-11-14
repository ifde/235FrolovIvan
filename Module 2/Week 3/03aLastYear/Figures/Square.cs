using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Square : Point
    {
        private double _side; // the legnth of the square's side

        public Square(int x, int y, int side)
        {
            _x = x;
            _y = y;
            _side = side;
        }

        /// <summary>
        /// A property for _side
        /// </summary>
        public double Side
        {
            get { return _side; }
        }

        override public string Display()
        {
            return $"A square with the center in ({_x}, {_y}) and side {_side}";
        }

        override public double Area
        {
            get { return _side * _side; }
        }

        /// <summary>
        /// Gets the perimetr of the square
        /// </summary>
        public double Len
        {
            get { return 4 * _side; }
        }
    }
}
