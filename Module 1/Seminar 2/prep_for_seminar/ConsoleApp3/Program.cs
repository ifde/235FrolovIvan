/*
  Дисциплина: "Программирование"
  Группа:      БПИ235(2)
  Студент:     Фролов Иван Григорьевич
  Задача:      Не используя методов класса Math вычислить значение an. 
Для n = 4 используя не более 2-х операций умножения, n = 6, 8 – не более 3-х; 
n = 7, 9, 10 – не более 4-х; n = 13, 15 – не более 5-ти; для n = 21, 28, 64 – не более 6-ти.
    Дата:      15.09.2023
*/

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            int n;
            do
            {
                Console.WriteLine("Введите число: ");
            } while (!double.TryParse(Console.ReadLine(), out a));
            do
            {
                Console.WriteLine("Введите степень числа: ");
            } while (!int.TryParse(Console.ReadLine(), out n));
            double a_2 = a * a; // 1
            double a_3 = a * a_2; // 2
            double a_4 = a_2 * a_2; // 2
            double a_5 = a_4 * a; // 3
            double a_6 = a_3 * a_3; // 3
            double a_7 = a_6 * a; // 4
            double a_14 = a_7 * a_7; // 5
            double a_8 = a_4 * a_4; // 3
            double a_16 = a_8 * a_8; // 4
            double a_32 = a_16 * a_16; // 5
            double a_64 = a_32 * a_32; // 6

            double res = a;
            res = n == 4 ? a_4 : res;
            res = n == 6 ? a_3 * a_3 : res; // 3
            res = n == 8 ? a_8 : res; // 3
            res = n == 7 ? a_3 * a_3 * a : res; // 4
            res = n == 9 ? a_3 * a_3 * a_3 : res; // 4
            res = n == 10 ? a_5 * a_5 : res ; // 4
            res = n == 13 ? a_6 * a_6 * a : res; // 5
            res = n == 15 ? a_5 * a_5 * a_5: res; // 5
            res = n == 21 ? a_7 * a_7 * a_7 : res; // 6
            res = n == 28 ? a_14 * a_14 : res; // 6
            res = n == 64 ? a_64 : res; // 5
            Console.WriteLine("Результат: " + res);
        }
    }
}
