
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Sphere : Shape3D
    {
        private double r; // the radius of the cube

        public Sphere()
        {
            r = 1 + rnd.NextDouble() * 99; // the random double value in [1, 100]
        }

        public override double S()
        {
            return 4 * Math.PI * r * r;
        }

        public override double V()
        {
            return 4 / 3 * Math.PI * r * r * r;
        }

        public override string ToString()
        {
            return $"r = {r:f2}";
        }
    }
}
