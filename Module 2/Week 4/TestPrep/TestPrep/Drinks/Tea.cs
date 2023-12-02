using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks
{
    public class Tea : Drink
    {
        override public double Price => price;

        public Tea(string name, double price) : base(name, price) { }

        public override string ToString()
        {
            return $"Name = {name:f2}. Price = {Price:f2}";
        }
    }
}
