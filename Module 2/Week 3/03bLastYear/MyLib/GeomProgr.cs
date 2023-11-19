using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class GeomProgr
    {
        // поле класса - счетчик созданных объектов: 
        public static uint objectNumber = 0;
        double _b; // первый член прогрессии b!=0
        double _q; // знаменатель прогрессии q!=0
        public double B
        {
            get { return _b; }
            set
            {
                if (value == 0)
                    throw new Exception("Недопустимое значение первого члена прогрессии!");
                _b = value;
            }
        }
        public double Q
        {
            get { return _q; }
            set
            {
                if (value == 0)
                    throw new Exception("Недопустимое значение знаменателя прогрессии!");
                _q = value;

            }
        }

        // Конструктор без параметров (конструктор умолчания):
        public GeomProgr()
        {
            _b = 1;
            _q = 1;
            objectNumber++;
            Console.WriteLine(objectNumber + ": Конструктор без параметров");
        }
        // Конструктор общего вида (конструктор с параметрами):
        public GeomProgr(double b, double q) : this()
        {
            if (b == 0 || q == 0)
            {
                objectNumber--;
                throw new ArgumentException("Ошибка в аргументах конструктора!");
            }
            _b = b;
            _q = q;
            Console.WriteLine(objectNumber + ": Конструктор с параметрами");
        }

        /// <summary>
        /// Gets the n_th element of the sequence
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public double this[int n]
        { 
 
            get
            {
                if (n <= 0) throw new ArgumentException("Неверное значение аргумента.");
                return _b* Math.Pow(_q, n - 1);
            }
        }

        /// <summary>
        /// Calculates the sum of the first n elements of the sequence
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public double ProgrSum(int n)
        { 
            if (n <= 0) throw new ArgumentException("Неверное значение аргумента.");
            return _b * (Math.Pow(_q, n) - 1) / (_q - 1);
        } 

    }
}
