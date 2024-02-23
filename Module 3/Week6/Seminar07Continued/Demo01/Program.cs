using Demo01Lib;

namespace Demo01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SideOfTheWorldEncoder sideOfTheWorldEncoder = new SideOfTheWorldEncoder();
            WindEncoder windEncoder = new WindEncoder();

            byte[] encoding1 = sideOfTheWorldEncoder.Encode("С");
            Console.WriteLine(ByteArrayToString(encoding1));
            Console.WriteLine(sideOfTheWorldEncoder.Decode(encoding1));

            byte[] encoding2 = windEncoder.Encode("СЗ");
            Console.WriteLine(ByteArrayToString(encoding2));
            Console.WriteLine(windEncoder.Decode(encoding2));

        }

        static string ByteArrayToString(byte[] arr)
        {
            string res = "";
            foreach (byte b in arr) res += b;
            return res;
        }
    }
}