
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
            Dictionary<string, byte[]> dict = GetDictionary();
            return dict[u];
            byte[] cipher = new byte[u.Length];
            for (int i = 0; i < u.Length; i++)
            {
                cipher[i] = (byte)((u[i] - 'A' + key) % 26);
            }
            return cipher;
        }

        public string Decode(byte[] t)
        {
            Dictionary<string, byte[]> dict = GetDictionary();
            foreach (var key in dict.Keys)
            {
                if (CompareByteArrays(dict[key], t)) return key;
            }
            throw new ArgumentException("Не удалость расшифровать.");
        }

        private bool CompareByteArrays(byte[] arr1, byte[] arr2)
        {
            if (arr1.Length != arr2.Length) return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }
            return true;
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

    public class WindEncoder : BinaryToStringEncoder
    {
        protected override Dictionary<string, byte[]> GetDictionary()
        {
            return new Dictionary<string, byte[]>
            {
                { "С", new byte[] { 0, 0, 0 } },
                { "Ю", new byte[] { 1, 0, 0 } },
                { "З", new byte[] { 1, 1, 0 } },
                { "В", new byte[] { 0, 1, 0 } },
                { "СЗ", new byte[] { 1, 1, 1 } },
                { "СВ", new byte[] { 0, 0, 1 } },
                { "ЮЗ", new byte[] { 1, 0, 1 } },
                { "ЮВ", new byte[] { 0, 1, 1 } }
            };
        }
    }

}