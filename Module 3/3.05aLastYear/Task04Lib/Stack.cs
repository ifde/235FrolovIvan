namespace Task04Lib
{
    public class Stack<T>
    {
        List<T> list = new List<T>();
        public Stack() { }

        public void Push(T obj)
        {
            list.Add(obj);
        }

        public T Pop()
        {
            if (list.Count == 0) throw new ApplicationException("Стек пуст!");
            T temp = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return temp;
        }
    }
}