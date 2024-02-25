using System.Runtime.InteropServices;
using Demo02Lib;

namespace Demo02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines(@"temp.txt");
                EvenSequence<int> evenSequence = new EvenSequence<int>();
                foreach (string temp in lines)
                {
                    int a;
                    int.TryParse(temp, out a);
                    try
                    {
                        evenSequence.AddNumber(a);
                    }
                    catch (Exception) { }
                    
                }
                Console.WriteLine(evenSequence);

                OddSequence<int> oddSequence = new OddSequence<int>();
                evenSequence = new EvenSequence<int>();
                do
                {
                    Console.Clear();
                    Console.WriteLine("Input an integer number");
                    int number;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out number)) break;
                        Console.WriteLine("Wrong input. Try again.");
                    }
                    try
                    {
                        evenSequence.AddNumber(number);
                        oddSequence.AddNumber(number);
                    }
                    catch (Exception) { }

                    Console.WriteLine("Press ESC to see the sequences.\nPrees any other key to continue your input.");

                } while (Console.ReadKey().Key != ConsoleKey.Escape);

                Console.WriteLine("Even Sequence:\n" + evenSequence);
                Console.WriteLine("Odd Sequence:\n" + oddSequence);
                
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Unsupported error occured.");
            }
            

        }
    }
}