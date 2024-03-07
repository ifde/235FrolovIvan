namespace Task04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numb = { "132-11-43", "342 11 23", "132-36-39" };
            // Запрос с отложенным исполнением:  
            // var res = numb.Where(p => p.StartsWith("132")); // 1*

            // Запрос с непосредственным исполнением:  
            var res = numb.Where(p => p.StartsWith("132")).ToArray();   // 2*

            Console.WriteLine("Выбраны из последовательности: ");
            foreach (var r in res)
                Console.WriteLine(r);

            numb[2] = "111-32-76";

            Console.WriteLine("После изменения источника данных: ");
            foreach (var r in res)
                Console.WriteLine(r);

        }
    }
}