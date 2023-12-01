using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Cube : Shape3D
    {
        private double a; // the side of the cube

        public Cube()
        {
            a = 1 + rnd.NextDouble() * 99; // the random double value in [1, 100]
        }

        public override double S()
        {
            return a * a * 6;
        }

        public override double V()
        {
            return a * a * a;
        }

        public override string ToString()
        {
            return $"a = {a:f2}";
        }
    }
}
