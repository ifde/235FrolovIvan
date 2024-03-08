using Task05Lib;

namespace Task05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] test = { "one", "two", "three", "four", "five", "zero" };
            Words words = new Words(test);
            Console.WriteLine("Названия цифр по алфавиту:");
            foreach (var item in words)
                foreach (var el in item)
                    Console.Write(el + "  ");
            Console.WriteLine();

            // Выберем из поcледовательности массив слов на букву 'f':
            var res = from s in words
                      where s.Length > 0 && s[0][0] == 'f'
                      select s;

            Console.WriteLine("Названия цифр на букву 'f':");
            foreach (var item in res)
                foreach (var el in item)
                    Console.WriteLine(el);

            Words keys = new Words(MyLib.keywords);
            int cnt = 0;
            foreach (var key in keys) cnt++;
            Console.WriteLine("Number of elements in keys[]:" + cnt);
            Console.WriteLine("This is because keys[] includes empty arrays.");

            // Выберем из поcледовательности массив слов на букву 'i':
            var set = from s in keys
                      where s.Length > 0 && s[0][0] == 'i'
                      select s;

            Console.WriteLine("Служебные слова на букву 'i':");
            foreach (var item in set)
                foreach (var el in item)
                    Console.WriteLine(el);

        }
    }
}