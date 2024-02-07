namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream(@"../../../mydata.txt", FileMode.Create))
            {
                BinaryWriter br = new BinaryWriter(fs);
                br.Write(0);
                br.Write(1);
                br.Write(2);
                br.Write(3);
                br.Write(4);
                br.Write(5);
            }

            using (FileStream fs = new FileStream(@"../../../mydata.txt", FileMode.Open))
            {
                BinaryReader br = new BinaryReader(fs);
                Console.WriteLine("Числа из файла в обратном порядке:");
                for (long i = -4; Math.Abs(i) <= fs.Length; i -= 4)
                {
                    fs.Seek(i, SeekOrigin.End);
                    Console.WriteLine(br.ReadInt32());
                }

                BinaryWriter bw = new BinaryWriter(fs);
                fs.Position = 0;
                Console.WriteLine("Увеличиваем все числа в пять раз");
                for (int i = 0; i < fs.Length / 4; i++)
                {
                    int a = br.ReadInt32() * 5;
                    fs.Position -= 4;
                    bw.Write(a);
                    Console.WriteLine(a);
                }
            }
        }
    }
}