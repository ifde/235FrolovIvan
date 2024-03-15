using System.Globalization;

namespace Main1Lib
{
    public class Ellipse
    {
        public double X { get; }
        public double Y { get; }

        public Ellipse(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double MinDiametr => Math.Min(X, Y);
        public double MaxDiametr => Math.Max(X, Y);

        public override string ToString()
        {
            return $"{X:f3} {Y:f3}";
        }
    }

    public class EllipseList
    {
        private Ellipse[] _Ellipses;
        private int[] indices;

        public Ellipse[] Ellipses { get { return _Ellipses; } }

        public EllipseList(string fileName)
        {
            string path = @"../../../../input/" + fileName + ".txt";
            try
            {
                string[] lines = File.ReadAllLines(path);

                _Ellipses = new Ellipse[lines.Length];
                int cnt = 0;
                foreach (string line in lines)
                {
                    // CultureInfo.CurrentCulture = new CultureInfo("en-US");
                    double x, y;
                    string[] sides = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (sides.Length != 2) continue;
                    if (!double.TryParse(sides[0], out x)) continue;
                    if (!double.TryParse(sides[1], out y)) continue;
                    _Ellipses[cnt++] = new Ellipse(x, y);
                }
                Array.Resize(ref _Ellipses, cnt);
            }
            catch (Exception)
            {
                _Ellipses = new Ellipse[0];
                return;
            }
            finally
            {
                indices = new int[_Ellipses.Length];
                for (int i = 0; i < indices.Length; i++)
                {
                    indices[i] = i;
                }
            }

        }

        public IEnumerable<Ellipse> GetIterator(int mode)
        {
            for (int i = 0; i < _Ellipses.Length - 1; i++)
            {
                for (int j = i + 1; j < _Ellipses.Length; j++)
                {
                    if (mode == 1)
                    {
                        if (_Ellipses[indices[i]].MinDiametr > _Ellipses[indices[j]].MinDiametr)
                        {
                            int temp = indices[i];
                            indices[i] = indices[j];
                            indices[j] = temp;
                        }
                    }
                    else
                    {
                        if (_Ellipses[indices[i]].MaxDiametr > _Ellipses[indices[j]].MaxDiametr)
                        {
                            int temp = indices[i];
                            indices[i] = indices[j];
                            indices[j] = temp;
                        }
                    }
                    
                }
            }

            for (int i = 0; i < indices.Length; i++)
            {
                yield return _Ellipses[indices[i]];
            }
        }
    }
}