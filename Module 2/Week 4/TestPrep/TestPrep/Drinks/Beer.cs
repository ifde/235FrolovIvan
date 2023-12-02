using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks
{
    public class Beer : Drink
    {
        private double coefficient;

        public Beer(string name, double price) : base(name, price)
        {
            coefficient = (double)random.Next(1, 100) / 10;
        }

        override public double Price => price * coefficient;
        public override string ToString()
        {
            return $"Name = {name:f2}. Price = {Price:f2}";
        }

    }
}
