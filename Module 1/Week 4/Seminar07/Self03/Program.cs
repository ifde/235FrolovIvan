/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self03
  Дата:      29.09.2023
*/

namespace Self03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int n; // количество ступенек треугольника
                int m; // количество секций ёлочки

                Console.WriteLine("Введите N:");
                // вводим количество ступенек треугольника
                while (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите N:");
                }

                Console.WriteLine("Введите M:");
                // количество секций ёлочки
                while (!int.TryParse(Console.ReadLine(), out m))
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите M:");
                }

                Ornament(n, m);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Выводим треугольник
        /// </summary>
        /// <param name="n"></param>
        static void Triagnle(int n)
        {
            if (n > 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine();
                }
            }
        }
        
        /// <summary>
        /// Улучшенный Ornament
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        static void Ornament(int n, int m)
        {
            if (m > 0)
            {
                // перебираем все cтроки
                int k = 1; // счетчик
                for (int i = 0; i < n; i++)
                {
                    // перебираем все столбцы
                    for (int j = 1; j <= n * m; j++)
                    {
                        Console.Write(j % n <= k && (j % n != 0 || i == n - 1) ? '*' : ' ');
                    }
                    Console.WriteLine();
                    k++;
                }
            }

        }
    }
}