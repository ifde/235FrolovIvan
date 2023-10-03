/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1
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

            int[,] matr = new int[3, 4] { { 0, 1, 3, 4 }, { 5, 6, 7, 8 }, { 9, -1, -2, -3 } };

            Console.WriteLine("matr.GetType() = " + matr.GetType());
            Console.WriteLine("matr.IsFixedSize = " + matr.IsFixedSize);
            Console.WriteLine("matr.Rank = " + matr.Rank);
            Console.WriteLine("matr.Length = " + matr.Length);
            Console.WriteLine("matr.GetLength(1) = " + matr.GetLength(1));
            Console.WriteLine("matr.GetUpperBound(1) = " + matr.GetUpperBound(0));  

            foreach (int memb in matr) // все элементы матрицы подряд
                Console.Write("{0,3}", memb);

            Console.WriteLine(Environment.NewLine);

            // вывод по строкам!!!
            for (int i = 0; i < matr.GetLength(0); i++, Console.WriteLine())
                for (int j = 0; j < matr.GetLength(1); j++)
                    Console.Write("{0,3}", matr[i, j]);


            Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

    /// <summary>
    /// Распечатать массив int[]
    /// </summary>
    /// <param name="arr"></param>
    static void PrintArray(uint[] arr)
    {
        if (arr.Length == 0)
        {
            Console.WriteLine("[]");
        }
        else
        {
            Console.Write("[");
            foreach (int elem in arr)
            {
                Console.Write($"{elem}, ");
            }
            Console.Write("\b\b]\n");
        }
    }
}