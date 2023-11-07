/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      КДЗ-1 (2 модуль)
 Дата:       03.11.23
*/
using CSV_ClassLibrary;
using System.Globalization;
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
                    CsvProcessing.path = Console.ReadLine() + "";

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

                    string[] new_lines = null; // selected lines or sorted lines depending on the command

                    switch (command)
                    {
                        case 1:
                            Console.WriteLine("\nВведите значение выборки District:"); // Нижегородский район
                            string district = Console.ReadLine() + "";

                            new_lines = DataProcessing.GetSelectedLines((4, district));

                            // cheking if no lines match the selection,
                            // meaning that new_lines[] contains only headers.
                            if (new_lines.Length == 2)
                            {
                                Console.WriteLine("Такой выборки не существует.");
                                throw new Exception("Kill program");
                            }
                            CsvProcessing.Print(new_lines);
                            break;

                        case 2:
                            Console.WriteLine("\nВведите значение выборки CarCapacity:");
                            string carCapacity = Console.ReadLine() + "";

                            new_lines = DataProcessing.GetSelectedLines((9, carCapacity));

                            // cheking if no lines match the selection,
                            // meaning that new_lines[] contains only headers.
                            if (new_lines.Length == 2)
                            {
                                Console.WriteLine("Такой выборки не существует.");
                                throw new Exception("Kill program");
                            }
                            CsvProcessing.Print(new_lines);
                            break;

                        case 3:
                            Console.WriteLine("\nВведите значение выборки Status:");
                            string status = Console.ReadLine() + "";

                            Console.WriteLine("\nВведите значение выборки NearStation:");
                            string nearStation = Console.ReadLine() + "";

                            nearStation = nearStation.Replace("<", "«");
                            nearStation = nearStation.Replace(">", "»");

                            new_lines = DataProcessing.GetSelectedLines((7, status), (5, nearStation));

                            // cheking if no lines match the selection,
                            // meaning that new_lines[] contains only headers.
                            if (new_lines.Length == 2)
                            {
                                Console.WriteLine("Такой выборки не существует.");
                                throw new Exception("Kill program");
                            }
                            CsvProcessing.Print(new_lines);
                            break;

                        case 4:
                            new_lines = DataProcessing.SortByColumn("AvailableTransfer");
                            CsvProcessing.Print(new_lines);
                            break;

                        case 5:
                            new_lines = DataProcessing.SortByColumn("YearOfComissioning");
                            CsvProcessing.Print(new_lines);
                            break;

                        case 6:
                            break;

                    }

                    // Checking if a user decided to kill program.
                    if (new_lines == null) throw new Exception("Kill program");

                    Console.WriteLine("\nДля сохранения данных нажмите ENTER.\nИначе нажмите любую другую клавишу.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("\nCSV-Файл будет сохранен в папке исполнимого файла консольного приложения.\nВведите желаемое имя файла:");
                        string file_name = Console.ReadLine() + ""; // file_name
                        while (true)
                        {
                            try
                            {
                                if (new_lines.Length == 3) CsvProcessing.Write(new_lines[2], file_name + ".csv");
                                else
                                {
                                    CsvProcessing.path = file_name + ".csv";
                                    CsvProcessing.Write(new_lines);
                                }

                                break;
                            }
                            catch (IOException)
                            {
                                Console.WriteLine("Неверно введено имя файла. Введите корректное имя:");
                                file_name = Console.ReadLine() + ""; // file_name
                            }
                        }
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
                catch (Exception e)
                {
                    if (e.Message != "Kill program") Console.WriteLine("Возникла непредвиденная ошибка.");
                }


                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}