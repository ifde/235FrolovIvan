/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      DIY01
   Дата:      26.09.2023
*/

namespace DIY02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения
            do
            {
                Console.Clear();

                int a, // очередное введенное число
                    sum = 0; // общая сумма все чисел
                int res = 0; // сумма отрицательных чисел
                uint n = 0; // количество отрицательных чисел

                // вводим очередное число число a
                Console.WriteLine("Вводите целые числа. Для завершения введите 0");
                while(sum >= -1000)
                {
                    // работаем с целыми отрицательными числами 
                    if (int.TryParse(Console.ReadLine(), out a) && a <= 0)
                    {
                        // при 0 прекращаем считывать числа
                        if (a == 0)
                        {
                            break;
                        }
                        n++;
                        res += a;
                        sum += a;
                    }  
                }

                Console.WriteLine($"Среднее арифметическое отрицательных чисел равно {(double)res / n}");

                Console.WriteLine("Для завершения программы нажмите ESC");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}