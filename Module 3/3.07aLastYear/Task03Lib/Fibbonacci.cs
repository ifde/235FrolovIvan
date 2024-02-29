using System.Collections;

namespace Task03Lib
{
    public class Fibbonacci
    {
        int last, current = 1;

        public IEnumerable<int> GetSequence(int cnt)
        {
            if (cnt <= 0) throw new ArgumentException("Negative numbers are not supported.");
            for (int i = 0; i < cnt; i++)
            {
                int t = current;
                current = last + current;
                last = t;
                yield return current;
            }
        }
    }

    public class TriangleNums
    {
        int n = 0;
        public IEnumerable<int> GetTriangleNums(int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                yield return n * (n  + 1) / 2;
                n++;
            }
        }
    }
}