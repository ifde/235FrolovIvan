using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class NumbJagged
    {
        private int[][] jarArr;

        /// <summary>
        /// The property for "jarArr"
        /// </summary>
        public int[][] JarAgg => jarArr;

        public NumbJagged()
        {
            jarArr = new int[0][];
        }

        public NumbJagged(int n)
        {
            // Because "n" is the argument of the NumbJagged() method, it is reasonable to throw ArgumentException() if the value of "n" is unacceptable
            if (n < 0) throw new ArgumentException("Значение аргумента не может быть отрицательным.");
            jarArr = new int[n][];
            List<int> list = new List<int>(); // contatins elements of the string
            Random rnd = new Random(); // randomizer
            int k; // a random number
            for (int i = 0; i < n; i++)
            {
                // filling list
                do
                {
                    k = rnd.Next(6);
                    list.Add(k);
                } while (k != 0);
                jarArr[i] = list.ToArray();
                list = new List<int>();
            }
        }
        
        /// <summary>
        /// Calculates the number 3-element tuples (where each element is the elemnt of jarArr[n]) which elements can form a triagle.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int TriangleNumber(int n)
        {
            // Because "n" is the argument of the NumbJagged() method, it is reasonable to throw ArgumentException() if the value of "n" is unacceptable
            if (n < 0 || n >= jarArr.Length) throw new ArgumentException("Некорректный номер строки массива.");

            int counter = 0; // method output
            for (int i = 0; i < jarArr[n].Length  - 2;  i++)
            {
                for (int j = i + 1; j < jarArr[n].Length - 1; j++)
                {
                    for (int k = j + 1; k < jarArr[n].Length; k++)
                    {
                        if (jarArr[n][i] + jarArr[n][j] > jarArr[n][k] &&
                            jarArr[n][i] + jarArr[n][k] > jarArr[n][j] &&
                            jarArr[n][k] + jarArr[n][j] > jarArr[n][i]) counter++;
                    }
                }
            }

            return counter;
        }

        /// <summary>
        /// Converts jarArr to a string[].
        /// </summary>
        /// <returns></returns>
        public string[] AsString()
        {
            string[] lines = new string[jarArr.Length];
            for (int i = 0; i < jarArr.Length; i++)
            {
                string line = "";
                for (int j = 0; j < jarArr[i].Length; j++)
                {
                    line += jarArr[i][j] + " ";
                }
                lines[i] = line;
            }
            return lines;
        }

    }
}
