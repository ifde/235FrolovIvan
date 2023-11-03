/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      КДЗ-1 (2 модуль)
 Дата:       03.11.23
*/
using CSV_ClassLibrary;


namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = CsvProcessing.Read();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}