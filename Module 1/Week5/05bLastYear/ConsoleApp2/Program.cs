/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2
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

            int n; // ранг матрицы 
            int[,] matr; // матрица

            Console.WriteLine("Введите целое неотрицательное число n:");
            while(!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine("Введите целое неотрицательное число n:");
            }

            matr = new int[n, n];
            for (int i = 0; i < n; i++, Console.WriteLine())
            {
                for (int j = 0; j < n; j++)
                {
                    matr[i, j] = (i + (j + 1)) % n;
                    Console.Write($"{matr[i, j],4}");
                }
            }


            Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

}