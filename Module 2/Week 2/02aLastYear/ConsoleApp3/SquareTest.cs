/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      3
Дата:        10.11.23
*/

namespace ConsoleApp3
{
    internal class SquareTest
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines(@"..\..\..\magicData.txt");    // читаем все строки файла в массив
                int lineIndex = 0;  // на какой строке файла находимся
                int count = 0; // считаем, на каком мы сейчас квадрате
                while (lines.Length > lineIndex)
                {
                    int size;   // размер квадрата
                    if (!int.TryParse(lines[lineIndex], out size))
                    {
                        Console.WriteLine($"Ошибка при чтении размера квадрата: {lines[lineIndex]} - не число (строка {lineIndex + 1})");
                        return;
                    }
                    if (size == -1)    // в конце файла ожидается -1
                        return;
                    lineIndex++;
                    Square square = new Square(size);
                    square.ReadSquare(lines, lineIndex);

                    Console.WriteLine($"\n******** Квадрат номер {++count} ********");
                    square.PrintSquare();

                    Console.WriteLine("\nСуммы элементов строк:");
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write(square.SumRow(i) + " ");
                    }
                    Console.WriteLine();

                    Console.WriteLine("\nСуммы элементов столбцов:");
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write(square.SumCol(i) + " ");
                    }
                    Console.WriteLine();

                    Console.WriteLine($"\nСумма элементов на главной диагонали:\n{square.SumMainDiag()}");
                    Console.WriteLine($"\nСумма элементов на побочной диагонали:\n{square.SumOtherDiag()}");

                    if (square.Magic()) Console.WriteLine("\nКвадрат является магическим!");
                    else Console.WriteLine("\nКвадрат НЕ является магическим.");

                    count++;
                    lineIndex += size;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}