using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04Lib
{
    public class test_cs
    {
        // по возрастанию значений
        static bool pred1(int x, int y) { return x > y; } //да-нет
        // в начале поместить четные
        static bool pred2(int a, int b)
        {
            if (a % 2 != 0 && b % 2 == 0) return true;
            else return false;
        }
        public static void Main()
        {
            Series row = new Series(8, 0, 21);
            row.Display();
            Console.WriteLine();
            row.Order(pred1); //назначен метод
            row.Display();
            Console.WriteLine();
            row.Order(pred2);
            row.Display();
            Console.WriteLine("\nДля выхода нажмите ENTER");
            Console.ReadLine();
        }
    } // test_cs

}
