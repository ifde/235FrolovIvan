using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class CompFunction
    {
        Function f, g; 

        public CompFunction(Function f, Function g)
        {
            this.f = f;
            this.g = g;
        }

        public CompFunction() : this(new Function(x => x), new Function(x => x)) { }

        public double GetValue(double x) => g.GetValue(f.GetValue(x));
    }
}
