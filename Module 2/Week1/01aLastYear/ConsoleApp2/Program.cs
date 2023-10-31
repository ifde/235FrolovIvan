/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2
 Дата:       31.10.2023
*/

namespace ConsoleApp2
{

    internal class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        /// <summary>
        /// Консруктор общего вида
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Point() { x = 0; y = 0; }

        /// <summary>
        /// Радиус в полярной системе координат
        /// </summary>
        public double ro
        {
            get
            {
                return Math.Sqrt(y * y + x * x);
            }
        }

        /// <summary>
        /// Угол в полярной системе координат
        /// </summary>
        public double Fi
        {
            get
            {
                if (x > 0 && y >= 0)
                {
                    return Math.Atan(y / x);
                }
                else if (x > 0 && y < 0)
                {
                    return Math.Atan(y / x) + 2 * Math.PI;
                }
                else if (x < 0)
                {
                    return Math.Atan(y / x) + Math.PI;
                }
                else if (x == 0 && y > 0)
                {
                    return 3 * Math.PI / 2;
                }
                else if (x == 0 && y < 0)
                {
                    return Math.PI / 2;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Информация о точке
        /// </summary>
        /// <returns></returns>
        public string Info()
        {
            return $"({x:f2}, {y:f2})";
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Повтор решения.
            do
            {
                Console.Clear();

                Point a = new Point(1, 2);
                Point b = new Point();
                double xc, yc; // координаты точки C

                // Вводим абсциссу точки C
                Console.WriteLine("Введите ненулевую абсциссу точки C:");
                while (!(double.TryParse(Console.ReadLine(), out xc) && xc != 0))
                {
                    Console.WriteLine("Wrong input.Try Again.");
                }

                // Вводим ординату точки C
                Console.WriteLine("Введите ненулевую ординату точки C:");
                while (!(double.TryParse(Console.ReadLine(), out yc) && yc != 0))
                {
                    Console.WriteLine("Wrong input.Try Again.");
                }

                Point c = new Point(xc, yc); // создаем точку C

                Point[] points = { a, b, c }; // массив точек A, B, C

                Array.Sort(points, (a, b) => (int)(a.ro - b.ro)); // сортировка
                foreach (Point p in points)
                {
                    Console.WriteLine(p.Info());
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}