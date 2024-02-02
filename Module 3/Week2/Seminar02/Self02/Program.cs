using Self02Lib;

namespace Self02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Input N - number of lines in the input file");
                int n = int.Parse(Console.ReadLine());
                Random rnd = new Random();
                using (StreamWriter sr = new StreamWriter(@"../../../input.txt"))
                {
                    for (int i = 0; i < n; i++)
                    {
                        sr.WriteLine(rnd.Next(-20, 20));
                    }
                    
                }
                using (StreamReader sr = new StreamReader(@"../../../input.txt"))
                {
                   
                    using (StreamWriter sw = new StreamWriter(@"../../../output.txt"))
                    {
                        int a = int.Parse(sr.ReadLine());
                        int b = int.Parse(sr.ReadLine());
                        int c = int.Parse(sr.ReadLine());

                        sw.WriteLine($"{Methods.Processing(a, b, c, (x, y, z) => (x + y + z) / 3, (a, b, c) => Math.Sqrt((a + b + c) / 2 * (a + b - c) / 2 * (a - b + c) / 2 * (-a + b + c) / 2), (a, b, c) => Math.Pow(a * b * c, 1 / 3)):f2}");

                        string? str;
                        while ((str = sr.ReadLine()) != null)
                        {
                            a = b;
                            b = c;
                            c = int.Parse(str);

                            sw.WriteLine(Methods.Processing(a, b, c, (x, y, z) => (x + y + z) / 3,
                           (a, b, c) => Math.Sqrt((a + b + c) / 2 * (a + b - c) / 2 * (a - b + c) / 2 * (-a + b + c) / 2),
                           (a, b, c) => Math.Pow(a * b * c, 1 / 3)));
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}