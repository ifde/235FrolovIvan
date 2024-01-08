using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03Lib
{
    public class Circle : IFigure
    {
        public double Radius { get; set; }

        public Circle(double r) { Radius = r; }

        public double Area
        {
            get { return Math.PI * Radius * Radius; }
        }

        public override string ToString()
        {
            return $"Circle with Raduis = {Radius}";
        }
    }
}
