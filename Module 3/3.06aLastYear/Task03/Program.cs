namespace Task03
{
    internal class Program
    {
        static void Main()
        {
            using (FileStream inFi =
               new FileStream(@"..\..\..\Program.cs", FileMode.Open))
            {
                int t;      // числовое значение прочитанного байта
                while ((t = inFi.ReadByte()) != -1)
                {
                    if (t >= '0' && t <= '9')
                        Console.WriteLine(t + " - " + (char)t + " - " + inFi.Position);
                }   // while
            }     // using
        }   // Main() 

    }
}