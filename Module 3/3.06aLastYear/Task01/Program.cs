using Task01Lib;

namespace Task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Input n:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out n)) break;
                Console.WriteLine("Wrong input. Try again.");
            }

            Random rnd = new Random();
            List<ColorPoint> points = new List<ColorPoint>();
            for (int i = 0; i < n; i++)
            {
                points.Add(new ColorPoint(rnd.NextDouble(),
                    rnd.NextDouble(),
                    rnd.Next(ColorPoint.colors.Length)));
            }

            string path = @"../../../MyTest.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (ColorPoint p in points)
                {
                    sw.WriteLine(p.ToString());
                }
            }

            List<ColorPoint> new_lst = new List<ColorPoint>();
            using (StreamReader sw = new StreamReader(path))
            {
                if (!File.Exists(path)) Console.WriteLine("Файл не найден!");
                else
                {
                    string? line;
                    while ((line = sw.ReadLine()) != null)
                    {
                        string[] values = line.Split("    ");
                        double x = double.Parse(values[0]);
                        double y = double.Parse(values[1]);
                        int color = 0;
                        for (int i = 0; i < ColorPoint.colors.Length; i++)
                        {
                            if (ColorPoint.colors[i] == values[2])
                            {
                                color = i;
                                break;
                            }
                        }
                        new_lst.Add(new ColorPoint(x, y, color));
                    }
                }
            }

            foreach (ColorPoint p in points)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}