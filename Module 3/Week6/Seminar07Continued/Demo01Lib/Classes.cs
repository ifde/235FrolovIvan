
namespace Demo01Lib
{
    public interface IEncrypted<T, TU>
    {
        T Encode(TU u);
        TU Decode(T t);
    }

    public abstract class BinaryToStringEncoder : IEncrypted<byte[], string>
    {
        protected abstract Dictionary<string, byte[]> GetDictionary();
        int key = 5;

        public byte[] Encode(string u)
        {
            Dictionary<string, byte[]> dict = new Dictionary<string, byte[]>();
            byte[] cipher = new byte[u.Length];
            for (int i = 0; i < u.Length; i++)
            {
                cipher[i] = (byte)((u[i] - 'A' + key) % 26);
            }
            return cipher;
            // return GetDictionary().
        }

        public string Decode(byte[] t)
        {
            // TODO 02: реализовать данный метод
            string res = "";
            foreach (byte b in t)
            {
                res += (b - 5) % 26 + 'A';
            }
            return res;
            // return GetDictionary().
        }
    }

    public class SideOfTheWorldEncoder : BinaryToStringEncoder
    {
        protected override Dictionary<string, byte[]> GetDictionary()
        {
            return new Dictionary<string, byte[]>
            {
                { "С", new byte[] { 0, 0 } },
                { "Ю", new byte[] { 1, 0 } },
                { "З", new byte[] { 1, 1 } },
                { "В", new byte[] { 0, 1 } }
            };
        }
    }
}