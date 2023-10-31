/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      3
Определить класс правильных многоугольников, в котором конструктор с умалчиваемыми значениями аргументов играет роль конструктора умолчания. Поля класса – число сторон (целое) и радиус вписанной окружности (вещественный). Свойства – периметр и площадь многоугольника. Общедоступный метод PolygonData() формирует и возвращает строку со значениями полей и свойств объекта.

В основной программе определить одну ссылку с типом класса.
Создать объект, используя конструктор умолчания, затем вводить характеристики многоугольника и выводить сведения о них.

 Дата:       31.10.2023
*/


using System.Drawing;

namespace ConsoleApp3
{
    internal class Polygon
    {
        int n; // number of sides
        double r; // radius
        double s { get { return n * r * r * Math.Tan(Math.PI / n); } } // area
        double p { get { return 2 * n * r * Math.Tan(Math.PI / n); } } // perimetr

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        public Polygon (int n = 3, double r = 1)
        {
            this.n = n;
            this.r = r;
        }

        /// <summary>
        /// Create a string with polygon's data
        /// </summary>
        /// <returns></returns>
        public string PolygonData()
        {
            return $"n = {n}, r = {r:f2}, s = {s:f2}, p = {p:f2}";
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

                Polygon P = new Polygon(); // new polygon
                int n; // number of sides
                double r; // radius

                // Вводим число строн мноугольника
                Console.WriteLine("Введите число сторон многоугольника:");
                while (!(int.TryParse(Console.ReadLine(), out n) && n > 0))
                {
                    Console.WriteLine("Wrong input.Try Again.");
                }

                // Вводим радиус мноугольника
                Console.WriteLine("Введите радиус многоугольника:");
                while (!(double.TryParse(Console.ReadLine(), out r) && r > 0))
                {
                    Console.WriteLine("Wrong input.Try Again.");
                }

                P = new Polygon(n, r);
                Console.WriteLine(P.PolygonData());

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}