/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      8
  Дата:      04.10.2023
*/

internal class Program
{
    static void Main(string[] args)
    {
        // повтор решения 
        do
        {
            Console.Clear();

            int an, am, bn, bm; // измерения матриц A и B соответсвенно
            int[,] a, b; // матрицы A и B соответсвенно

            // Вводим число строк матрицы A
            Console.WriteLine("Введите число строк матрицы A:");
            while (!int.TryParse(Console.ReadLine(), out an) || an <= 0)
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine("Введите число строк матрицы A:");
            }

            // Вводим число столбцов матрицы A
            Console.WriteLine("Введите число столбцов матрицы A:");
            while (!int.TryParse(Console.ReadLine(), out am) || am <= 0)
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine("Введите число столбцов матрицы A:");
            }

            // Вводим число строк матрицы B
            Console.WriteLine("Введите число строк матрицы B:");
            while (!int.TryParse(Console.ReadLine(), out bn) || bn <= 0)
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine("Введите число строк матрицы B:");
            }

            // Вводим число столбцов матрицы B
            Console.WriteLine("Введите число столбцов матрицы B:");
            while (!int.TryParse(Console.ReadLine(), out bm) || bm <= 0)
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine("Введите число столбцов матрицы B:");
            }

            a = CreateMatrix(am, an);
            b = CreateMatrix(bm, bn);
            int[,] c = MatrixMult(a, b); // произведение матриц A и B
            Console.WriteLine('\n' + "Матрица A:");
            Console.WriteLine(MatrixToString(a) + '\n');
            Console.WriteLine("Матрица B:");
            Console.WriteLine(MatrixToString(b) + '\n');
            Console.WriteLine(c == null ? "Матрицы перемножить нельзя." : $"Матрица A x B\n{MatrixToString(c)}");

            Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

    /// <summary>
    /// Создать матрицу M x N, заполненную случайными значениями из диапазона [1;10]
    /// </summary>
    /// <param name="m"></param>
    /// <param name="n"></param>
    /// <returns>Возвращает целочисленную матрицу размера M, N</returns>
    static int[,] CreateMatrix(int m, int n)
    {
        int[,] matr = new int[m, n]; // итоговая матрица
        Random random = new Random();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matr[i, j] = random.Next(1, 11);
            }
        }

        return matr;
    }

    /// <summary>
    /// Возвращает целочисленную матрицу представляющую произведение матриц A и B. Возвращает null, если матрицы перемножить нельзя
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    static int[,] MatrixMult(int[,] a, int[,] b)
    {
        // если матрицы перемножить нельзя, то возвращаем null
        if (a.GetLength(1) != b.GetLength(0))
        {
            return null;
        }
        int[,] mult = new int[a.GetLength(0), b.GetLength(1)]; // итоговое произведение матриц
        // перемножаем матрицы по определению
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                mult[i, j] = 0;
                for (int k = 0; k < b.GetLength(0); k++)
                {
                    mult[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return mult;
    }

    /// <summary>
    /// Возвращает строку с табличным представлением матрицы
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    static string MatrixToString(int[,] a)
    {
        string res = ""; // итоговая строка
        for (int i = 0; i < a.GetLength(0); i++)
        {
            res += '\n';
            for (int j = 0; j < a.GetLength(1); j++)
            {
                res += $"{a[i, j],4}";
            }
        }

        return res;
    }
}