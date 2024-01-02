using Task1Lib;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> temp = new List<string>();
            Console.WriteLine("Вводите строки ниже. Для завершения нажмите ESC");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                temp.Add(Console.ReadLine() + "");
            }
            string[] arr = temp.ToArray();

            ConvertRule cvr = RemoveDigits;
            cvr += RemoveSpaces;

            Console.WriteLine("Измененные строки:\n--------\n");
            foreach (string s in arr)
            {
                string tmp = s;
                foreach (ConvertRule convertRule in cvr.GetInvocationList())
                {
                    tmp = convertRule(tmp);
                    Console.WriteLine(tmp);
                }
                Console.WriteLine("--------\n");
            }

        }

        public static string RemoveDigits(string str)
        {
            List<char> list = new List<char>();
            foreach (char c in str)
            {
                if (!char.IsDigit(c)) list.Add(c);
            }
            return new string(list.ToArray());
        }

        public static string RemoveSpaces(string str)
        {
            List<char> list = new List<char>();
            foreach (char c in str)
            {
                if (c != (char)32) list.Add(c); // check is the symbol is white SPACE
            }
            return new string(list.ToArray());
        }
    }
}