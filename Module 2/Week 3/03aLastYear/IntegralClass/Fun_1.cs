using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralClass
{
    public class Fun_1 : OneArgumentFunction
    {
        public Fun_1(double xmin, double xmax)
        {
            Xmax = xmax; 
            Xmin = xmin;
        }

        public override double Function(double x)
        {
            return 4 * Math.Cos(x) * Math.Cos(x);
        }
    }
}
