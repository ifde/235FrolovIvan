using Task2Lib;

namespace ConsoleApp2
{
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

                    Random rnd = new Random();
                    int a = rnd.Next(10000, 100000);
                    int[] arr = new int[10];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = rnd.Next(10, 100);
                    }

                    Row row = Class2.GetDigits;
                    Print print = Class2.PrintArray;

                    Console.WriteLine("Row: " + row.Method + " " + row.Target);
                    Console.WriteLine("Print: " + print.Method + " " + print.Target);

                    Console.WriteLine("Исходное число: " + a);
                    print.Invoke(row(a));
                    Console.Write(Environment.NewLine);

                    foreach (int i in arr)
                    {
                        Console.WriteLine(i);
                        print(row(i));
                        Console.Write(Environment.NewLine);
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