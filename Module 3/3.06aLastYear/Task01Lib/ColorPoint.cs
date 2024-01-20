namespace Task01Lib
{
    public class ColorPoint
    {
        public static string[] colors = { "Red", "Green", "DarkRed", 
            "Magenta", "DarkSeaGreen", "Lime", 
            "Purple", "DarkGreen", "DarkOrange", 
            "Black", "BlueViolet", "Crimson", 
            "Gray", "Brown", "CadetBlue" };
        public double x, y;
        public string color;
        public override string ToString()
        {
            string format = "{0:F3}    {1:F3}    {2}";
            return string.Format(format, x, y, color);
        }

        public ColorPoint(double x, double y, int color)
        {
            this.x = x;
            this.y = y;
            this.color = colors[color];
        }
    }

}