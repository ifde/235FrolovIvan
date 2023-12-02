
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks
{
    public class Vine : Drink
    {
        private double coefficient;

        public Vine(string name, double price) : base(name, price)
        {
            coefficient = (double)random.Next(50, 355) / 10;
        }

        override public double Price => price * coefficient;
        public override string ToString()
        {
            return $"Name = {name:f2}. Price = {Price:f2}";
        }
    }
}
