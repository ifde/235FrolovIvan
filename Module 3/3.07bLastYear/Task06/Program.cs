using Task06Lib;
using System.Linq;

namespace Task06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rainbow colors = new Rainbow();
            Console.WriteLine("Исходная последовательность:");
            foreach (string color in colors)
                Console.Write(color);

            Console.WriteLine("\r\nВыборка коротких слов:");
            var u = colors.Where(x => x.Length <= 6);

            foreach (string color in u)
                Console.Write(color);

            Console.WriteLine("\r\nСлова упорядочены по длинам:");
            IEnumerable<string> seq = colors.OrderBy(x => x.Length);

            foreach (string color in seq)
                Console.Write(color);

            Console.WriteLine("\r\nСлова упорядочены по алфавиту:");
            IEnumerable<string> pre = colors.OrderBy(x => x.ToString());

            foreach (string color in pre)
                Console.Write(color);

            Console.WriteLine("\r\nДля выхода нажмите ENTER...");
            Console.ReadLine();

        }
    }
}