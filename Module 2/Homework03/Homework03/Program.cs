/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      КДЗ-3 (2 модуль)
Вариант:     4
Дата:        05.12.23
*/

using CsvClassLibrary;

namespace Homework03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Театр[] theatres;
                Console.WriteLine("Введите имя файла:");
                string path = $@"..\..\..\..\{Console.ReadLine()}.csv";

                theatres = CsvProcessing.Read(path);
                //int[] maxes = new int[22];
                //for (int i = 0; i < theatres.Length - 1; i++)
                //{
                    
                //}
                CsvProcessing.Print(theatres);
                Console.WriteLine(theatres[0].MainHallCapacity);
                theatres = CsvProcessing.SortByCapacity(theatres, false);
                CsvProcessing.Print(theatres, "MainHallCapacity", "AdditionalHallCapacity");
                CsvProcessing.Write(theatres, @"..\..\..\..\Output");

            }
            catch (Exception)
            {
                Console.WriteLine("Возникла ошибка.");
            }
            

        }
    }
}