/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      КДЗ-1 (2 модуль)
 Дата:       03.11.23
*/
using CSV_ClassLibrary;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                try
                {
                    // input path
                    Console.WriteLine("Введите абсолютный путь к файлу с CSV-данными:");
                    CsvProcessing.path = Console.ReadLine();

                    CsvProcessing.Read(); // immiadetly catching an exception if the path is incorrect

                    int command; // chosen command
                    Console.WriteLine("\n---------\nМеню:\n" +
                        "1. Произвести выборку по значению District\n" +
                        "2. Произвести выборку по значению CarCapacity\n" +
                        "3. Произвести выборку по значениям Status и NearStation\n" +
                        "4. Отсортировать таблицу по значению AvailableTransfer (алфавитный порядок)\n" +
                        "5. Отсортировать таблицу по значению YearOfComissioning (по убыванию)\n" +
                        "6. Выйти из программы\n---------\n\n" +
                        "Укажите номер пункта меню для запуска действия:");
                    // input command
                    while (true)
                    {

                        if (int.TryParse(Console.ReadLine(), out command)) break;
                        Console.WriteLine("Такой команды не существует. Повторите попытку.");
                    }

                    switch (command)
                    { 
                        case 1:
                            if (DataProcessing.GetSelectedFields("District").Length == 0)
                            {
                                Console.WriteLine("Такой выборки не существует.");
                                break;
                            }
                            CsvProcessing.Print(DataProcessing.GetSelectedFields("District"));
                            break;

                        case 2:
                            if (DataProcessing.GetSelectedFields("CarCapacity").Length == 0)
                            {
                                Console.WriteLine("Такой выборки не существует.");
                                break;
                            }
                            CsvProcessing.Print(DataProcessing.GetSelectedFields("CarCapacity"));
                            break;

                        case 3:
                            if (DataProcessing.GetSelectedFields("Status", "NearStation").Length == 0)
                            {
                                Console.WriteLine("Такой выборки не существует.");
                                break;
                            }
                            CsvProcessing.Print(DataProcessing.GetSelectedFields("Status", "NearStation"));
                            break;

                        case 4:
                            CsvProcessing.Print(DataProcessing.SortByColumn("AvailableTransfer"));
                            break;

                        case 5:
                            CsvProcessing.Print(DataProcessing.SortByColumn("YearOfComissioning"));
                            break;

                    }
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.ParamName);
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Возникла непредвиденная ошибка.");
                }


                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}