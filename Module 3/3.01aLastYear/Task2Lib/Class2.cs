using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Lib
{
    public static class Class2
    {
        /// <summary>
        /// Creast an array of digits of a given integer.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[] GetDigits(int a)
        {
            List<int> res = new List<int>();
            while (a != 0)
            {
                res.Add(a % 10);
                a /= 10;
            }
            res.Reverse();

            return res.ToArray();
        }

        /// <summary>
        /// Prints an array of digits.
        /// </summary>
        /// <param name="a"></param>
        public static void PrintArray(int[] a)
        {
            Console.WriteLine("Массив цифр:\n" + string.Join(" ", a));
        }
    }
}
