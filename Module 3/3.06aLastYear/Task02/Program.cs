using System;
using System.IO;
class Program
{
    static void Main()
    {
        FileInfo fi = new FileInfo(@"Alphabet.txt");
        using (FileStream fs = fi.Open(FileMode.OpenOrCreate))
        {
            long len = fs.Length;   // Размер файла
            if (len == 26) Console.WriteLine("Aлфавит собран!");
            else
            {
                if (len == 0) Console.WriteLine("Файл пуст!");
                fs.Seek(len, SeekOrigin.Begin);
                byte bt = (byte)('A' + len);
                fs.WriteByte(bt);
                Console.WriteLine("Добавляем в файл букву " + (char)bt);
            }
            Console.WriteLine("Буквы в файле:");
            fs.Seek(0, SeekOrigin.Begin);
            int u;
            while ((u = fs.ReadByte()) != -1) Console.Write((char)u + "  ");
            Console.WriteLine();

            Console.WriteLine("Укажите букву для замены:");
            char symbol;
            char.TryParse(Console.ReadLine(), out symbol);
            Console.WriteLine(symbol);

            fs.Seek(0, SeekOrigin.Begin);
            while ((u = fs.ReadByte()) != -1)
            {
                if ((char)u == symbol) fs.Position -= 1;  fs.WriteByte((byte)'*'); break;
            }

            fs.Seek(0, SeekOrigin.Begin);
            while ((u = fs.ReadByte()) != -1) Console.Write((char)u + "  ");
            Console.WriteLine();
        }
    }
}
