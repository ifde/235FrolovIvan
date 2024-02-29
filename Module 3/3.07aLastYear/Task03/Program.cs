using Task03Lib;

namespace Task03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input M:");
            int m;

            int.TryParse(Console.ReadLine(), out m);
            int[] sum = new int[m];
            Fibbonacci fi = new Fibbonacci();
            TriangleNums triangles = new TriangleNums();

            int i = 0;
            foreach (int numb in fi.GetSequence(m))
            {
                Console.Write(numb + "  ");
                sum[i++] = numb;
            }
                
            Console.WriteLine();
            i = 0;
            foreach (int numb in triangles.GetTriangleNums(m))
            {
                Console.Write(numb + "  ");
                sum[i++] += numb;
            }
                
            Console.WriteLine();

            Console.WriteLine("The sum:");
            foreach (int elem in sum)
            {
                Console.Write(elem + "  ");
            }
            Console.WriteLine();


        }
    }
}