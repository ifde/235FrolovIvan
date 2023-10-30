/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Вариант:     XXX
 Дата:       21.10.2023
*/


using System;

namespace ConsoleApp1
{
    internal class Program
    {
        int f = 1;

        void Method1 ()
        {
            f++;
        }

        //static void Method2 ()
        //{
        //    f++;
        //}
        static void Main(string[] args)
        {
            int f = 2;
            int @if;
            void Method()
            {
                f++;
            }
            Console.WriteLine(Convert.ToString(-1U, toBase: 2));
            int r = 3;
            bool w = (r < ++r) || (++r > r++);
            Console.WriteLine(w);

            Method();
            {
                int x = 1, y = 2;
                int z = ((x | y + ++x) > 5) ? x | y : ++x + 2;
                Console.WriteLine($"{x} {y} {z}");
            }

            int[] l = { 1 };

            // повтор решения 
            do
            {
                //Console.Clear();

                byte t = 56;
                t += 214;
                Console.WriteLine(t);

                int[][] c;
                int n;
                // input N
                Console.WriteLine("Введите целое число N (0 < N < 7)");
                while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n >= 7)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите целое число N (0 < N < 7)");
                }
                c = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    int k, m;
                    // input K
                    Console.WriteLine("\nВведите целое число K (0 <= K < 15)");
                    while (!int.TryParse(Console.ReadLine(), out k) || k < 0 || k >= 15)
                    {
                        Console.WriteLine("Wrong input.");
                        Console.WriteLine("Введите целое число K (0 <= K < 15)");
                    }

                    // input M
                    Console.WriteLine("\nВведите целое число M (0 <= M < 15)");
                    while (!int.TryParse(Console.ReadLine(), out m) || m < 0 || m >= 15)
                    {
                        Console.WriteLine("Wrong input.");
                        Console.WriteLine("Введите целое число M (0 <= M < 15)");
                    }

                    int[] a = ArrayProcessing.CreateArray(k);
                    Console.WriteLine($"\nМассив A: {ArrayProcessing.AsString(a)}");

                    int[] b = ArrayProcessing.CreateArray(m);
                    Console.WriteLine($"\nМассив B: {ArrayProcessing.AsString(b)}");

                    ArrayProcessing.MergeArray(a, b, out c[i]);
                    Console.WriteLine($"\nC[{i}]: {ArrayProcessing.AsString(c[i])}");
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static void InputInt(out int a, int left, int right, string name)
        {
            Console.WriteLine($"\nВведите целое число {name} ({left} <= {name} < {right})");
            while (!int.TryParse(Console.ReadLine(), out a) || a < 0 || a >= 15)
            {
                Console.WriteLine("Wrong input.");
                Console.WriteLine("Введите целое число K (0 <= K < 15)");
            }
        }

        static void Test1(int a, params int[] b)
        {

        }

        static void Test1(int a, params string[] b)
        {

        }
    }
}