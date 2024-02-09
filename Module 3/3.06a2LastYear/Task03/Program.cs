namespace Task03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter(@"../../../numbers.txt"))
            {
                Random rnd = new Random();
                Console.WriteLine("Numbers from the file:");
                for (int i = 0; i < 100; i++)
                {
                    double temp = rnd.NextDouble() * 900 + 100;
                    sw.WriteLine(temp);
                    Console.WriteLine($"{temp:f3}");
                    
                }
                sw.Flush();
            }

            using (StreamReader sr = new StreamReader(@"../../../numbers.txt"))
            {
                Console.SetIn(sr);
                double n, sum = 0;
                int cnt = 0;
                while (double.TryParse(Console.ReadLine(), out n))
                {
                    sum += n;
                    cnt++;
                }
                Console.WriteLine("\n\nCalculated average:");
                Console.WriteLine("{0:f2}", sum / cnt);
                Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            }

            Console.WriteLine("Checking if the stream was restored:");
            Console.WriteLine(Console.ReadLine());
        }
    }
}