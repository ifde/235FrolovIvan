using System.Collections;

namespace Task05Lib
{
    public class MyIterator<T> : IEnumerable<T>
    {
        T[] collection;
        int start;
        public MyIterator(T[] collection, int start)
        {
            if (start >= collection.Length || start < 0) throw new ArgumentException();
            this.collection = collection;
            this.start = start;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < collection.Length; i++)
            {
                yield return collection[(i + start) % collection.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class BFIterator<T> : IEnumerable<T>
    {
        T[] collection;
        public BFIterator(T[] collection)
        {
            this.collection = collection;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < collection.Length; i++)
            {
                yield return collection[i];
            }
            for (int i = collection.Length - 1;  i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}