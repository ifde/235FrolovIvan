/*
   Дисциплина: "Программирование"
   Группа:      БПИ235(2)
   Студент:     Фролов Иван Григорьевич
   Задача:      1
     Дата:      14.09.2023
*/

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double temp;
            Console.WriteLine("Введите число X: ");
            string res = double.TryParse(Console.ReadLine(), out temp) ? Formula(temp) : "Неверные входные данные";
            Console.WriteLine(@"Результат: {0:f5}", res);
        }
        static string Formula(double x)
        {
            double a  = Math.Abs(Math.Log10(Math.Pow(x, 2)));
            double b = Math.Sqrt(Math.Pow(Math.E, x / Math.PI) + Math.Pow(x, 1.0 / 3) + 1.4);
            double res = a / b;
            return res.ToString();
        }
    }
}