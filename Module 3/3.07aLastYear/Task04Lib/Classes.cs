using System.Collections;

namespace Task04Lib
{
    public class Evens
    {
        int nMin, nMax;
        public Evens (int min, int max)
        {
            if (min > max) throw new ArgumentException();
            nMin = min;
            nMax = max;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = nMin; i <= nMax; i++)
            {
                if (i % 2 == 0) yield return i;
            }
        }
    }

    public class Primes
    {
        int nMin, nMax;
        public Primes(int min, int max)
        {
            if (min > max) throw new ArgumentException();
            nMin = min;
            nMax = max;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = nMin; i <= nMax; i++)
            {
                if (IsPrime(i)) yield return i;
            }
        }

        private bool IsPrime(int n)
        {
            if (n == 1 || n == -1) return false;
            for (int i = 2;  i < (n > 0 ? n : -n) / 2; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}