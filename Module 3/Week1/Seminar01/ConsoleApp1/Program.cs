using Task01Lib;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = { "123df", "sdf dfdf324", "abcdef"};
            ConvertRule cr = RemoveDigits;
            cr += RemoveSpaces;

            foreach (string line in lines)
            {
                string tmp_line = line;
                foreach(ConvertRule tmp in cr.GetInvocationList())
                {
                    tmp_line = tmp?.Invoke(tmp_line);
                }
                Console.WriteLine(tmp_line);
            }
        }

        public static string RemoveDigits(string str)
        {
            string res = "";
            foreach (char ch in str)
            {
                if (!char.IsDigit(ch)) res += ch;
            }
            return res;
        }

        public static string RemoveSpaces(string str)
        {
            return str.Replace(" ", "");
        }
    }
}