/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      6
// Определите и инициализируйте массив строк.
// Выведите строки в порядке возрастания их длин.
// Порядок элементов в исходном массиве строк не менять (сортировка индексов).
  Дата:      04.10.2023
*/


internal class Program
{
    private static void Main(string[] args)
    {
        // повтор решения 
        do
        {
            Console.Clear();

            string[] lines = new string[] { "нуль", "один", "два",
                                            "три", "четыре", "пять", "шесть", 
                                            "семь", "восемь", "девять", "десять" };

            Console.WriteLine("\nИсходный массив:");
            foreach (string s in lines)
                Console.Write(s + " ");

            int[] index = new int[10];
            for (int i = 0; i < index.Length; i++)
            {
                index[i] = i;
            }

            Array.Sort(index, (s1, s2) => CompareLength(lines[s1], lines[s2]));
            Console.WriteLine("\nОтсортированный массив:");
            foreach (int i in index)
                Console.Write(lines[i] + " ");

            Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

    static int CompareLength(string s1, string s2)
    {
        return s1.Length > s2.Length ? 1 : -1;
    }

    /// <summary>
    /// Создать и вернуть Треугольник Паскаля - массив int[][];
    /// </summary>
    /// <param name="n">количество строк в треугольнике Паскаля</param>
    static int[][] CreatePascalTriangle(int n)
    {
        int[][] pascal = new int[n][]; // массив для треугольника Паскаля
        for (int i = 0; i < n; i++)
        {
            if (i == 0) // первую строку заполняем вручную
            {
                pascal[i] = new int[1] { 1 };
            }
            else // остальные строки заполняем рекурсивно
            {
                pascal[i] = new int[i + 1];
                pascal[i][0] = 1;
                for (int j = 0; j < i - 1; j++) // данную строку формируем по предыдущей
                {
                    pascal[i][j + 1] = pascal[i - 1][j] + pascal[i - 1][j + 1];
                }
                pascal[i][^1] = 1;
            }
        }

        return pascal;
    }

    /// <summary>
    /// Напечатать треугольник Паскаля (зубчатый массив int[][]). Выводим строку 
    /// </summary>
    /// <param name="matr"></param>
    static string PrintPascalTriangle(int[][] arr)
    {
        string text = "";
        int num = arr.Length; // вспомогательное число для вычисления изначального смещения строки вправо
        foreach (int[] row in arr)
        {
            Console.Write(new String(' ', (2 * num - 1) /*изначальное смещение строки вправо*/));
            text += new String(' ', 2 * num - 1); // записываем в выводимый текст
            for (int i = 0; i < row.Length; i++)
            {
                Console.Write($"{row[i]}   ");
                text += $"{row[i]}   "; // записываем в выводимый текст
            }
            Console.WriteLine();
            text += "\n"; // записываем в выводимый текст
            num--;
        }

        return text;
    }

}