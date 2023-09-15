/*
  Дисциплина: "Программирование"
  Группа:      БПИ235(2)
  Студент:     Фролов Иван Григорьевич
  Задача:      Задача 3. Задача на применение тернарной операции. 
                (Не применять оператор if.)
                Написать метод, так обменивающий значения трех переменных x, y, z, чтобы выполнилось требование: x <= y <= z. 

                В основной программе, вводить значения трех переменных и упорядочивать их с помощью обращения к написанному методу. 

                Для выхода из программы вводите ESC, для повторения решения – любую другую клавишу. 

    Дата:      15.09.2023
*/

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, y, z;
            Console.WriteLine("Введите x:");
            double.TryParse(Console.ReadLine(), out x);
            Console.WriteLine("Введите y:");
            double.TryParse(Console.ReadLine(), out y);
            Console.WriteLine("Введите z:");
            double.TryParse(Console.ReadLine(), out z);

            double one = x < y ? (z < x ? z : x) : (z < y ? z : y);
            double three = z > y ? (z > x ? z : x) : (x > y ? x : y);
            double two = (x + y + z) - one - three;

            Console.WriteLine($"Ответ:\n{one}\n{two}\n{three}");
        }
    }
}