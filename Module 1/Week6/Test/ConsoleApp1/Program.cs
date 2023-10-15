/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Вариант:      12

Дата:      14.10.2023
*/

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                double[] arr; // array
                uint n; // size of Array

                Console.WriteLine("Введите размер массива:");
                // input a length of arr
                while (!uint.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите размер массива:");
                }
                arr = new double[n];
                var rand = new Random(); // Random numbers generator

                // Filling arr with random doubles from 101 to 999
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = 101 + 898 * rand.NextDouble();
                }

                Console.WriteLine("Исходный массив:");
                Console.WriteLine(ArrayProcessing.DblArrToString(arr));

                Console.WriteLine("Полученный массив:");
                ArrayProcessing.UpOn10(arr);
                Console.WriteLine(ArrayProcessing.DblArrToString(arr));

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}