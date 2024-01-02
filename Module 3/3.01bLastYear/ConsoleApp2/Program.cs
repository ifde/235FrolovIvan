using Task2Lib;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Использование делегатов для управления событиями *****\n");

            Car c1 = new Car("SlugBug", 100, 10);

            // Передаём в машину метод, который будет вызван при отправке оповещения.
            c1.RegisterWithCarEngine(OnCarEngineEvent);
            // Разгоняем машину
            Console.WriteLine("***** Увеличиваем скорость *****");
            int temp = c1.CurrentSpeed;
            for (int i = 0; i < 10; i++)
            {
                c1.Accelerate(20);
                temp += 20;
                if (temp - 20 >= c1.MaxSpeed) break;
            }
                
            Console.ReadLine();
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Сообщение от объекта типа Car *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************\n");
        }

    }
}