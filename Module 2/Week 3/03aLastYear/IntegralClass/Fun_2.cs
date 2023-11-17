using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralClass
{
    public class Fun_2 : OneArgumentFunction
    {
        public Fun_2(double xmin, double xmax)
        {
            Xmax = xmax;
            Xmin = xmin;
        }

        public override double Function(double x)
        {
            double denominator = (x * x + 1) * (x * x + 1);
            return x / denominator;
        }
    }
}
