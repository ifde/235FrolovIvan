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
                EvenSequence<int> evenSequence = new EvenSequence<int>(x => x < 21);
                foreach (string temp in lines)
                {
                    int a;
                    int.TryParse(temp, out a);
                    evenSequence.AddNumber(a);
                }
                Console.WriteLine(evenSequence);
                
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