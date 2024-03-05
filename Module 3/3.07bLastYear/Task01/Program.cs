namespace Task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Маша", "Вася", "Наташа", "Петя", "Ира", "Даня" };
            Array.ForEach(names, Console.WriteLine);
            Console.WriteLine("======================= Manual: ");
            
            IEnumerable<string> namesWithSh = from name in names
                                              where name.Contains("ш") && name.Contains("а")
                                              orderby name descending
                                              select name;
            foreach (string name in namesWithSh)
            {
                Console.Write(name + " ");
            }

        }
    }
}