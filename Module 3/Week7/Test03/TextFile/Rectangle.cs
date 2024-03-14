using System.Globalization;

namespace TextFile
{
    public class Rectangle
    {
        public double X { get; }
        public double Y { get; }

        public Rectangle(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Area => X * Y;

        public override string ToString()
        {
            return $"{X:f3} {Y:f3}";
        }
    }

    public class RectangleList
    {
        private Rectangle[] _rectangles;
        private int[] indices;

        public Rectangle[] Rectangles { get { return _rectangles; } }

        public RectangleList(string fileName)
        {
            string path = @"../../../../data/" + fileName + ".txt";
            try
            {
                string[] lines = File.ReadAllLines(path);

                _rectangles = new Rectangle[lines.Length];
                int cnt = 0;
                foreach (string line in lines)
                {
                    // CultureInfo.CurrentCulture = new CultureInfo("en-US");
                    double x, y;
                    string[] sides = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (sides.Length != 2) continue;
                    if (!double.TryParse(sides[0], out x)) continue;
                    if (!double.TryParse(sides[1], out y)) continue;
                    _rectangles[cnt++] = new Rectangle(x, y);
                }
                Array.Resize(ref _rectangles, cnt);
            }
            catch (Exception)
            {
                _rectangles = new Rectangle[0];
                return;
            }
            finally
            {
                indices = new int[_rectangles.Length];
                for (int i = 0; i < indices.Length; i++)
                {
                    indices[i] = i;
                }
            }
            
        }

        public IEnumerable<Rectangle> GetIterator(int mode)
        {
            for (int i = 0; i < _rectangles.Length - 1; i++)
            {
                for (int j = i + 1; j < _rectangles.Length; j++)
                {
                    if (mode * _rectangles[i].Area > mode * _rectangles[j].Area)
                    {
                        int temp = indices[i];
                        indices[i] = indices[j];
                        indices[j] = temp;
                    }
                }
            }

            for (int i = 0; i < indices.Length; i++)
            {
                yield return _rectangles[i];
            }
        }
    }
}