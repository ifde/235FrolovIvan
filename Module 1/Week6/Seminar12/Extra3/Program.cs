/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Билет №2 Задача 4

Создать два двухмерных массива целых чисел  размером NхM и заполнить его случайными числами из диапазона  от –10 до 10. 
Определить  строки первой матрицы, зеркально симметричные хотя бы одной строке второй матрицы. 
Исходные матрицы и номера пар зеркально симметричных строк вывести на экран. 
Значения N и M вводятся с клавиатуры.

  Дата:      20.10.2023
*/

namespace Extra3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // повтор решения 
            do
            {
                Console.Clear();

                int[,] a, b;
                int n, m;

                Console.WriteLine("Введите натурльное число N:");
                while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
                {
                    Console.WriteLine("Wrong Input");
                    Console.WriteLine("Введите натурльное число N:");
                }

                Console.WriteLine("Введите натурльное число M:");
                while (!int.TryParse(Console.ReadLine(), out m) || m < 0)
                {
                    Console.WriteLine("Wrong Input");
                    Console.WriteLine("Введите натурльное число M:");
                }

                a = new int[m, n];
                b = new int[m, n];
                var rnd = new Random();
                int[] indices = new int[m]; // массив с номерами симметричных строк матриц A и B.
                int k = 0; // длина массива indices[]

                // заполняем массив A
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = rnd.Next(-10, 11);
                    }
                }

                // заполняем массив B и сразу считаем симметричные строки
                for (int i = 0; i < m; i++)
                {
                    bool flag = true; // a flag to determine whether a string in B is symmetrical
                                      // to a corresponding string in A
                    for (int j = 0; j < n; j++)
                    {
                        b[i, j] = rnd.Next(-10, 11);
                        for (int t = 0; t < m; t++) // пробегаем по всем строкам матрицы A
                        {
                            if (b[i, j] != a[t, n - 1 - j]) // проверяем симметричность
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag) indices[k++] = i;
                }
                Array.Resize(ref indices, k);

                Console.WriteLine("\nМассив A:");
                PrintArray(a);
                Console.WriteLine("\nМассив B:");
                PrintArray(b);
                Console.WriteLine("\nНомера симметричныых строк:");
                PrintArray(indices);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Print int[,]
        /// </summary>
        /// <param name="arr"></param>
        static void PrintArray(int[,] arr)
        {
            int cnt = 0; // counter
            foreach (int elem in arr)
            {
                Console.Write($"{elem} ");
                cnt++;
                if (cnt % arr.GetLength(0) == 0) Console.WriteLine();
            }
        }

        /// <summary>
        /// Print int[]
        /// </summary>
        /// <param name="arr"></param>
        static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(' ', arr));
        }
    }
}