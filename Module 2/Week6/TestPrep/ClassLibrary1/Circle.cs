using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    public class Circle : IComparable
    {
        private double r;
        private Point point;
        public double R // radius
        { 
            get { return r; }
            set
            {
                if (value <= 0) throw new ArgumentException("Значение радиуса не может быть меньше 0.");
                r = value;
            }
        } 

        public Circle(Point point, double r)
        {
            this.point = point;
            R = r;
        }

        public Circle() : this(new Point(0, 0), 1) { }

        public double S => Math.PI * r * r;

        public int CompareTo(object circle)
        {
            return S.CompareTo( ((Circle)circle).S );
        }

        public override string ToString()
        {
            return $"Окружность с центром в точке {point:f2} и радиусом {R:f2}. Площадь = {S:f2}";
        }
    }
}
