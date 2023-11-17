using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralClass
{
    public class Fun_3 : OneArgumentFunction
    {
        public Fun_3(double xmin, double xmax)
        {
            Xmax = xmax;
            Xmin = xmin;
        }

        public override double Function(double x)
        {
            return Math.Cos(x * x * x);
        }
    }
}
