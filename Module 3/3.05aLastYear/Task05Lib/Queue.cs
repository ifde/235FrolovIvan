namespace Task05Lib
{
    public class Queue<T>
    {
        List<T> list = new List<T>();
        public void Enqueue(T obj)
        {
            list.Add(obj);
        }

        public T Dequeue()
        {
            if (list.Count == 0) throw new ApplicationException("The queue is empty!");
            T temp = list[0];
            list.RemoveAt(0);
            return temp;
        }

        public T First => IsEmpty ? throw new ApplicationException("The queue is empty!") : list[0];
        public T Last => IsEmpty ? throw new ApplicationException("The queue is empty!") : list[list.Count - 1];

        public bool IsEmpty => list.Count == 0 ? false : true;

        public int Capacity => list.Count;
    }
}