/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      5
// Определить массив массивов для представления треугольника Паскаля.
// 0-й элемент - массив из одного элемента со значением С(0,0)=1, 
// 1-й элемент - массив из 2-х элементов С(1,0)=С(1,1)=1.
// 2-й элемент - массив из 3-х элементов С(2,0)=С(2,2)=1, С(2,1)=2...
// n-й элемент - массив из n+1 элементов: С(n,0)=С(n,n)=1, 
//   С(n,k)=C(n-1,k-1)+C(n-1,k). 
// Вводя неотрицательные значение n, построить массив-массивов  
// со значениями биномиальных коэффициентов и вывести его на экран 
// с помощью циклов foreach, размещая значения элементов каждого
// массива нижнего уровня на отдельной строке...
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

            int n; // количество строк Треугольника Паскаля
            Console.WriteLine("Введите количество строк Треугольника Паскаля:");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine("количество строк Треугольника Паскаля:");
            }

            PrintPascalTriangle(CreatePascalTriangle(n));
            File.WriteAllText("D:\\Text.txt", PrintPascalTriangle(CreatePascalTriangle(n)));

            Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

    /// <summary>
    /// Создать и вернуть Треугольник Паскаля - массив int[][];
    /// </summary>
    /// <param name="n">количество строк в треугольнике Паскаля</param>
    static int[][] CreatePascalTriangle (int n)
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