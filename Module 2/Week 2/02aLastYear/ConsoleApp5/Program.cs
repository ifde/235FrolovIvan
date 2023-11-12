using System.ComponentModel.DataAnnotations;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            // a separate videofile
            VideoFile myfile = new VideoFile(GenerateString(rnd.Next(2, 10)), 
                rnd.Next(60, 361), rnd.Next(100, 1001));
            Console.WriteLine("Отдельный видеофайл:\n" + myfile + "\n");


            // an array of videofiles
            VideoFile[] arr = new VideoFile[rnd.Next(5, 16)];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new VideoFile(GenerateString(rnd.Next(2, 10)), rnd.Next(60, 361), rnd.Next(100, 1001));
                if (arr[i].Size > myfile.Size) Console.WriteLine(arr[i] + "\n");
            }

        }

        /// <summary>
        /// Generates a string of latin symbols of a given size
        /// </summary>
        /// <param name="legnth"></param>
        /// <returns></returns>
        static string GenerateString(int length)
        {
            if (length <= 0) return "";
            Random rnd = new Random();
            char[] temp = new char[length]; // an array of symbols
            for (int i = 0; i < length; i++)
            {
                temp[i] = (char)('a' + rnd.Next('z' - 'a' + 1));
            }
            return new string(temp);
        }
    }
}