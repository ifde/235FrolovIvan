using Task03Lib;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Circle[] arr1 = new Circle[5];
            Square[] arr2 = new Square[5];

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = new Circle(rnd.NextDouble());
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = new Square(rnd.NextDouble());
            }

            GetInfo(arr1, 1);
            GetInfo(arr2, 1);
        }

        static void GetInfo<T>(T[] obj, double limit) where T : IFigure
        {
            foreach (var t in obj)
            {
                if (t.Area > limit) Console.WriteLine(t);
            }
        }
    }
}