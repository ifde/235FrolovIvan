using Task04Lib;

namespace Task04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Input a directory");
                string dir = Console.ReadLine() + "";
                Signature.AnalyzeDirectoryFiles(dir);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


    }
}