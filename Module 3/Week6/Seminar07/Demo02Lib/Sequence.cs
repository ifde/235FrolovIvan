using System.Runtime.CompilerServices;

namespace Demo02Lib
{
    public class Sequence<T>
    {
        T[] _seq;

        public T this[int i]
        {
            get
            {
                if (i < 0 || i  >= _seq.Length) throw new IndexOutOfRangeException();
                return _seq[i];
            }

            set { _seq[i] = value; }
        }

        public Sequence(T[] seq)
        {
            if (seq == null) throw new ArgumentNullException(nameof(seq));
            _seq = seq;
        }

        public Sequence() : this(new T[0]) { }
    }
}