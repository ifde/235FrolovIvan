/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      3
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

            char[][][] arr = new char[3][][];
            Random rand = new(); // генеарция случайных чисел
            arr[0] = new char[3][] { new char[2] { 'a', 'a' }, new char[3] { 'a', 'a', 'a' }, new char[4] { 'a', 'a', 'a', 'a' } };
            arr[1] = new char[2][] { new char[2] { 'a', 'a' }, new char[3] { 'a', 'a', 'a'} };
            arr[2] = new char[1][] { new char[4] { 'a', 'a', 'a', 'a'} };

            Console.WriteLine("arr.Rank = " + arr.Rank);
            Console.WriteLine("arr[0].Rank = " + arr[0].Rank);
            Console.WriteLine("arr[0][0].Rank = " + arr[0][0].Rank);
            Console.WriteLine("arr.Length = " + arr.Length);
            Console.WriteLine("arr.GetLength(0) = " + arr.GetLength(0));

            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine($"arr.GetLength({i}) = " + arr.GetLength(i));
            //}
            Console.WriteLine("arr.GetLength(0) = " + arr.GetLength(0));
            Console.WriteLine("arr.GetUpperBound(1) = " + arr.GetUpperBound(0));

            foreach (char[][] level0 in arr)
            {
                Console.WriteLine("Уровень 1");
                foreach (char[] level1 in level0)
                {
                    Console.WriteLine("\tУровень 2");
                    Console.Write("\t\t");
                    foreach (char level2 in level1)
                    {
                        Console.Write($"{level2,03}");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

}