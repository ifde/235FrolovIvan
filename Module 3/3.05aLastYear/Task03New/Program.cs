using System.Runtime.InteropServices;
using Task03NewLib;

namespace Task03New
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Square[] arr1 = new Square[5];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = new Square(i);
            }

            Circle[] arr2 = new Circle[5];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = new Circle(i);
            }

            PrintInfo(arr1, 5);
            PrintInfo(arr2, 5);

            arr1 = arr1.SelectByPredicate((square) => square.Area > 5);
            PrintInfo(arr1, -1);

        }

        static void PrintInfo<T>(T[] figures, double limit)
            where T: class, IFigure
        {
            foreach (var f in figures)
            {
                if (f.Area > limit) Console.WriteLine(f);
            }
        }

        
    }

    static class MyClass
    {
        public static T[] SelectByPredicate<T>(this T[] mass, Func<T, bool> predicate)
        {
            List<T> lst = new List<T>();
            foreach (var f in mass) if (predicate(f)) lst.Add(f);
            return lst.ToArray();
        }
    }
}