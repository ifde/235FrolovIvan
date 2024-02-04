using System.Drawing;

namespace Task03Lib
{
    public class MyColor
    {
        string name;
        byte r, g, b;

        public string Name => name;
        public Color GetColor => Color.FromArgb(r, g, b);

        public MyColor(string name, byte[] bytes)
        {
            this.name = name;
            r = bytes[0]; 
            g = bytes[1]; 
            b = bytes[2];
        }

        /// <summary>
        /// Converts a color in "#f0f8ff" format to an array of R, G, B bytes
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static byte[] StringToColor(string str)
        {
            if (str.Length != 7) throw new ArgumentException();
            byte[] bytes = new byte[3];
            string r = str[1..3];
            string g = str[3..5];
            string b = str[5..7];

            Color temp = Color.FromArgb(Convert.ToInt32(r, 16), Convert.ToInt32(g, 16), Convert.ToInt32(b, 16));
            bytes[0] = temp.R;
            bytes[1] = temp.G;
            bytes[2] = temp.B;

            return bytes;
        }
    }
}