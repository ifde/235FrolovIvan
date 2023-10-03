/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      4
Ввести положительные значения N и M. Построить двумерный 
целочисленный массив (матрицу) с размерами N на M, элементы 
которого a[i, j] = (i+1)*(2*j+1), для i от 0 до (N-1), 
j от 0 до (M-1). 
Вывести матрицу в виде таблицы, а также значения свойств 
Rank и Length. 
  Дата:      03.10.2023
*/


internal class Program
{
    private static void Main(string[] args)
    {
        // повтор решения 
        do
        {
            Console.Clear();

            int n, m; // положительные значения n и m
            int[,] arr; // матрица n * m

            Console.WriteLine("Введите положительное число n:");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine("Введите целое неотрицательное число n:");
            }

            Console.WriteLine("Введите положительное число m:");
            while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine("Введите целое неотрицательное число n:");
            }

            arr = CreateMatrix(n, m);

            Console.WriteLine("matr.Rank = {0}", arr.Rank);
            Console.WriteLine("matr.Length = {0}", arr.Length);

            PrintMatrixRank2(arr);

            // матрица из задачи 2
            int[,] matr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matr[i, j] = (i + (j + 1)) % n;
                }
            }

            Console.WriteLine("\nЗаменяем все элементы под побочной диагональнью квадратной матрицы из второй задачи нулями:");
            ChangeUnderDiagonal(matr);
            PrintMatrixRank2(matr);

            Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

    /// <summary>
    /// Напечатать матрицу int[,]
    /// </summary>
    /// <param name="matr"></param>
    static void PrintMatrixRank2(int[,] matr)
    {
        int n = matr.GetLength(0); // первое измерение
        int m = matr.GetLength(1); // второе измерение
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{matr[i, j],4}");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Заменить все элементы под побочной диагональнью квадратной матрицы нулями
    /// </summary>
    /// <param name="matr"></param>
    static void ChangeUnderDiagonal(int[,] matr)
    {
        int n = matr.GetLength(0); // тип матрицы

        if (matr.GetLength(1) == n) // проверяем, что матрица квадратная
        {
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = n - 1 - i; j < n; j++)
                {
                    matr[i, j] = 0;
                }
            }
        }

    }

    /// <summary>
    /// Создать матрицу m * n, где matr[i, j] = (i+1)*(2*j+1)
    /// </summary>
    /// <param name="n">Число строк</param>
    /// <param name="m"> Число столбцов</param>
    static int[,] CreateMatrix(int n, int m)
    {
        int[,] matr = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matr[i, j] = (i + 1) * (2 * j + 1);
            }
        }

        return matr;
    }

}