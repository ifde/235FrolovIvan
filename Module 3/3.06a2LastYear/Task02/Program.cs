namespace Task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream(@"../../../numbers.bat", FileMode.Create))
            {
                BinaryWriter br = new BinaryWriter(fs);
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    br.Write(rnd.Next(1, 101));
                }
            }

            using (FileStream fs = new FileStream(@"../../../numbers.bat", FileMode.Open))
            {
                BinaryReader br = new BinaryReader(fs);
                List<int> numbers = new List<int>();
                Console.WriteLine("Numbers from the file:");
                while (true)
                {
                    try
                    {
                        int number = br.ReadInt32();
                        numbers.Add(number);
                        Console.WriteLine(number);
                    }
                    catch (EndOfStreamException)
                    {
                        break;
                    }
                }

                do
                {
                    Console.WriteLine("\nInput integer in [1;100]:");
                    int n;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out n) && n >= 1 && n <= 100) break;
                        Console.WriteLine("Wrong input. Try again.");
                    }
                    int dist = Math.Abs(n - numbers.First()); // the min distance between n and numbers from the "numbers" list
                    int target = numbers.First(); // the number that realizes "dist"
                    foreach (int i in numbers)
                    {
                        if (Math.Abs(i - n) < dist) { dist = Math.Abs(i - n); target = i; }
                    }

                    BinaryWriter bw = new BinaryWriter(fs);
                    Console.WriteLine($"\nNew numbers:\n({target} is about to be replaced)");
                    List<int> new_numbers = new List<int>();
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == target) { bw.Write(n); Console.WriteLine(n); new_numbers.Add(n); }
                        else { bw.Write(numbers[i]); Console.WriteLine(numbers[i]); new_numbers.Add(numbers[i]); }
                    }
                    numbers = new_numbers; // updating numbers

                    Console.WriteLine("\n\n-----------\nPress ESC to finish the program.\nPress any other key to continue.\n-----------");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
        }
    }
}