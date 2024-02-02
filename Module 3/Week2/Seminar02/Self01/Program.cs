namespace Self01
{
    delegate int Plus(int a, int b);
    delegate int Minus(int a, int b);
    delegate int Mult(int a, int b);
    delegate int Dev(int a, int b);

    enum Operations
    {
        Plus, Minus, Mult, Dev
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Plus plus = (a, b) => a + b;
            Minus minus = (a, b) => a - b;
            Mult mult = (a, b) => a * b;
            Dev dev = (a, b) => a / b;

            Delegate[] operations = { plus, minus, mult, dev};

            while(true)
            {
                Console.WriteLine("Введите строку в формате Op x1 x2");
                string[] elems = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(Calculate(elems[0], int.Parse(elems[1]), int.Parse(elems[2])));
                Console.WriteLine("Для завершения программы введите ESC. Для продолжения - любую другую клавишу.");
                if (Console.ReadKey().Key == ConsoleKey.Escape) break;
                Console.Clear();
            }
            



        }

        static int Calculate(string op, int a, int b)
        {
            Plus plus = (a, b) => a + b;
            Minus minus = (a, b) => a - b;
            Mult mult = (a, b) => a * b;
            Dev dev = (a, b) => a / b;

            Delegate[] operations = { plus, minus, mult, dev };

            switch (op)
            {
                case "+":
                    return ((Plus)operations[(int)Operations.Plus])(a, b);
                case "-":
                    return ((Minus)operations[(int)Operations.Minus])(a, b);
                case "*":
                    return ((Mult)operations[(int)Operations.Mult])(a, b);
                case "/":
                    return ((Dev)operations[(int)Operations.Dev])(a, b);
                default:
                    throw new ArgumentException("Такой операции не предусмотрено.");
            }
        }
    }
}