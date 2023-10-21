using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ArrayProcessing
    {
        /// <summary>
        /// Create an array consisting of N random integers from 10 to 65
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Created array</returns>
        public static int[] CreateArray(int n)
        {
            int[] arr = new int[n]; // initialize an output array
            Random rnd = new Random(); // random numbers generator

            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(10, 66);
            }
            return arr;
        }

        /// <summary>
        /// Create a string from an Array. Separator - "; "
        /// </summary>
        /// <param name="ar"></param>
        /// <returns>Created string. </returns>
        public static string AsString(int[] ar)
        {
            string res = ""; // method output
            if (ar == null || ar.Length == 0) return res; // return an empty string if ar[] contains no elements
            return string.Join("; ", ar);
        }

        public static void MergeArray(int[] a, int[] b, out int[] c)
        {
            a ??= new int[0]; // if a[] is null, create an empty array
            b ??= new int[0]; // if b[] is null, create an empty array
            c = new int[Math.Max(a.Length, b.Length)];

            for (int i = 0; i < c.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (i >= a.Length) c[i] = 0;
                    else c[i] = a[i];
                }
                else
                {
                    if (i >= b.Length) c[i] = 0;
                    else c[i] = b[i];
                }
            }
        }
    }
}
