namespace ConsoleApp1
{
    delegate int Cast(double a);
    internal class Program
    {
        static void Main(string[] args)
        {
            // repeat program
            do
            {
                try
                {
                    Console.Clear();

                    Cast cast1, cast2;
                    int c = (int)1.2;
                    cast1 = a => (int)Math.Floor(a) % 2 == 0 ? (int)Math.Floor(a) : (int)Math.Floor(a) + 1;
                    cast2 = delegate (double a)
                    {
                        int res = 0;
                        while (a >= 10)
                        {
                            res++;
                            a /= 10;
                        }
                        return res;
                    };

                    Console.WriteLine("Введите вещественное значение:");
                    double a;
                    while (true)
                    {
                        if (double.TryParse(Console.ReadLine(), out a)) break;
                        Console.WriteLine("Повторите попытку.");
                    }
                    // Console.WriteLine("Ближайшее чётное целое число: " + cast1(a));
                    // Console.WriteLine("Порядок: " + cast2(a));

                    Cast cast = cast1 + cast2;
                    foreach (Delegate temp in cast.GetInvocationList())
                    {
                        Console.WriteLine(((Cast)temp).Invoke(a));
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Возникла непредвиденная ошибка.");
                }

                Console.WriteLine("\n\n------------\nДля завершение программы введите Enter.\nДля продолжения - любую другую клавишу.\n------------\n");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
        }
    }
}