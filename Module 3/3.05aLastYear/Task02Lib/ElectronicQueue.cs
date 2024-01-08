namespace Task02Lib
{
    public class ElectronicQueue<T>
        where T : struct
    {
        private Queue<T> electronicQueue = new Queue<T>();
        public void AddToElectronicQueue(Person p)
        {
            electronicQueue.Enqueue(p);
        }
        public string CallFromElectronicQueue()
        {
            // получаем значение первого элемента очереди
            T tmp = electronicQueue.Peek(); 
            return tmp.ToString();
        }
        public void DeleteFromElectronicQueue()
        {
            electronicQueue.Dequeue(); // убирает первого из очереди
        }
    }

}