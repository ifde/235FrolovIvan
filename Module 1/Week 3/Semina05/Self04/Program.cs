/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      Self04
   Дата:      24.09.2023
*/

namespace Self04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine($"Бесконечная сумма равна {Sum()}");

                Console.WriteLine("Для завершения программы нажмите ESC");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Считаем бесконечную сумму 1 / 1*2*3 + 1/ 2*3*4 + ...
        /// </summary>
        /// <returns></returns>
        static double Sum()
        {
            double s, s1 = 0; // Итоговая и временая сумма соответственно
            uint i = 0; // counter
            double eps = 0.000001; // погрешность
            do
            {
                i++;
                s = s1;
                s1 += 1.0 / (i * (i + 1) * (i + 2));
            } while (s1 - s > eps);

            return s;
        }
    }
}