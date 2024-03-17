using System.Collections;
using System.Globalization;

namespace Main1Lib
{
    public class Circle
    {
        public double R { get; }

        public Circle(double r)
        {
            R = r;
        }

        public override string ToString()
        {
            return $"{R:f3}";
        }
    }

    public class CircleList : IEnumerable<Circle>
    {
        private Circle[] _circles;

        public Circle[] Circles { get { return _circles; } }

        public CircleList(string fileName)
        {
            string path = @"../../../../inputMain3/" + fileName + ".txt";
            try
            {
                string[] lines = File.ReadAllLines(path);

                List<Circle> temp = new List<Circle>();
                foreach (string line in lines)
                {
                    // CultureInfo.CurrentCulture = new CultureInfo("en-US");
                    double r;
                    string[] radiuses = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    foreach (string radiuse in radiuses)
                    {
                        if (!double.TryParse(radiuse, out r) || r < 0) continue;
                        temp.Add(new Circle(r));
                    }
                    
                }
                _circles = temp.ToArray();
            }
            catch (Exception)
            {
                _circles = new Circle[0];
                return;
            }

        }

        public IEnumerable<Circle> GetIterator(int mode)
        {

            Array.Sort(_circles, (a, b) => (a.R - b.R) * mode > 0 ? 1 : -1);

            foreach (var circle in _circles) yield return circle;
        }

        public IEnumerator<Circle> GetEnumerator()
        {
            foreach (var circle in _circles) yield return circle;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}