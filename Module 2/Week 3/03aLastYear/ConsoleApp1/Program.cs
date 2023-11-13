namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            A[] arr = new A[10];
            for (int i = 0; i < arr.Length; i++)
            {
                if (rnd.Next(2) == 0) arr[i] = new A();
                else arr[i] = new B();
            }

            Console.WriteLine("Все элементы массива.");
            foreach (A elem in arr)
            {
                elem.PrintA();
            }

            Console.WriteLine("\nТолько объекты типа A");
            foreach (A elem in arr)
            {
                if (elem.GetType() == typeof(A)) elem.PrintA();
            }

            Console.WriteLine("\nТолько объекты типа B");
            foreach (A elem in arr)
            {
                if (elem.GetType() == typeof(B)) elem.PrintA();
            }
        }
        class A
        {
            virtual public void PrintA() { Console.Write("A "); }
        }
        class B : A
        {
            override public void PrintA() { Console.Write("B "); }
        }

    }
}