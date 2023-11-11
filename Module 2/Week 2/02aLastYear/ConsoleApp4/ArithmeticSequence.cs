using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class ArithmeticSequence
    {
        private double _start; // the first value of a sequence
        private double _increment; // difference

        public ArithmeticSequence()
        {
            _start = 0;
            _increment = 1;
        }

        public ArithmeticSequence(double start, double increment)
        {
            _start = start;
            _increment = increment;
        }

        public double this[int index]
        {
            get {  return _start + _increment * (index - 1); }
        }

        public override string ToString()
        {
            return $"a1 = {_start}, d = {_increment}";
        }

        /// <summary>
        /// Calculates the sum of the frist n elements of a sequence.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public double GetSum(int n)
        {
            if (n <= 0) throw new Exception("Количество элементов должно быть натуральным числом.");
            return n * (_start + _increment * (n - 1) / 2);
        }
    }
}
