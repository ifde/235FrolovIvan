namespace Demo06
{
    public enum Answers
    {
        Yes,
        No,
        Maybe,
        Most_Definitely,
        Unknown,
        Unclear,
        ItDepends
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Input your question");
                string question = Console.ReadLine() + "";
                Console.WriteLine(GetRandomAnswer(new Answers()));

                Console.WriteLine("\n\n--------\nESC to kill the program. Any other key to continue.\n--------\n");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            

        }

        static string GetRandomAnswer(Answers answers)
        {
            Random rnd  = new Random();
            int number = rnd.Next(Enum.GetNames(answers.GetType()).Length);
            string? value = Enum.GetName(answers.GetType(), number);

            if (value == null) throw new NullReferenceException();
            return value;
        }
    }
}