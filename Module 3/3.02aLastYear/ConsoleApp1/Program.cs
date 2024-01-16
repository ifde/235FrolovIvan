namespace ConsoleApp1

{

    internal class Program
    {
        static event Action Ev; // событие

        // набор обработчиков
        static void F1() { Console.WriteLine("F1"); }
        static void F2() { Console.WriteLine("F2"); }
        static void F3() { Console.WriteLine("F3"); }

        static void Main(string[] args)
        {
            Ev += F1;
            Ev += F2;
            Ev += F3;

            Ev += delegate () { Console.WriteLine("F4"); };
            Ev += () => Console.WriteLine("F5");

            Ev -= F2;
            Ev -= F3;

            Ev?.Invoke();
        }
    }
}