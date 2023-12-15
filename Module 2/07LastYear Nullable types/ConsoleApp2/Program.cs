namespace ConsoleApp2
{
    internal class Program
    {
        static Program()
        {
            ch = (char)(ch - j);
        }
        static string str = "AaBbCc";
        static char ch = str[j + 4];
        static int j = 2;
        // Сначала зануляем все поля -
        // Потом инициализируем их -
        // потом статический конструктор - Потом выполняем функцию Main(string[] args)

        static void Main(string[] args)
        {
            //A obj = new A();
            //obj.ar[0] = 1;
            //A obj1 = new A(obj);
            //obj.ar[0] = obj1.ar[2] = obj.ar.Length;
            //foreach (int temp in obj1.ar)
            //    Console.WriteLine(temp);

            Console.Write(ch + str + j);

            //uint n = 3;
            //string line = "";
            //try
            //{
            //    Console.Write("Введите натуральное число:");
            //    line = Console.ReadLine();
            //    n = uint.Parse(line);
            //}
            //catch (Exception) { Console.Write(line + n++); }
            //finally
            //{
            //    Console.Write(line + n++);
            //}
            //Console.Write("12"[2]);
        }
    }

    class A
    {
        public int[] ar;
        public A() { ar = new int[3]; }
        public A(A o) { ar = o.ar; }

    }
}