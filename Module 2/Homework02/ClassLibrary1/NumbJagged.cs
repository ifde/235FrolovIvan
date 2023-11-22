using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class NumbJagged
    {
        private int[][] jarArr;

        public NumbJagged(int n)
        {
            jarArr = new int[n][];
            List<int> list = new List<int>();
            Random rnd = new Random();
            int k; // a random number
            for (int i = 0; i < n; i++)
            {
                do
                {
                    k = rnd.Next(6);
                    list.Add(k);
                } while (k != 0);
                jarArr[i] = list.ToArray();
            }
        }

        public int TriangleNumber(int n)
        {
            if (n < 0 || n >= jarArr.Length) throw new ArgumentException();
        }

    }
}
