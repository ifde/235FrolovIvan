namespace ConsoleApp2
{
    public class Publisher
    { // класс-издатель
        public event Action SomethingHappened; // событие

        public void FireEvent()
        {
            Console.WriteLine("SomethingHappened!");
            SomethingHappened?.Invoke(); // запуск события!!!
        }
    }

    // класс-подписчик на SomethingHappened
    public class SomethingHappenedSubscriber
    {
        public void SomethingHappenedHandler()
        {
            // код обработки события
            Console.WriteLine("Subscriber has handled an event!");
        }
    }

    public class AnotherClass
    {
        public static void AnotherHandler()
        {
            Console.WriteLine("Another Class has handled an event!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // объект класса-источника
            Publisher pub = new Publisher();
            // объект класса-подписчика
            SomethingHappenedSubscriber shs =
                new SomethingHappenedSubscriber();
            // добавляем подписчика к событию
            pub.SomethingHappened += shs.SomethingHappenedHandler;
            pub.SomethingHappened += AnotherClass.AnotherHandler;
            // вызвали метод, запускающий событие
            pub.FireEvent();
        }
    }
}