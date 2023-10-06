/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self01-02
  Дата:      06.10.2023
*/

namespace Self01_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int n; // длина массива
                double[] a; // массив вещественных чисел длины n
                Console.WriteLine("Введите размер массива A:");
                // вводим длину массива A
                while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите размер массива A:");
                }
                a = new double[n];
                Class1.Fill_Array(a, n);
                Class1.Print_Array(a);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}