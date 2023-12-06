/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      КДЗ-3 (2 модуль)
Вариант:     4
Дата:        05.12.23
*/

using CsvClassLibrary;
using System.Xml;

namespace Homework03
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
                    Театр[] theatres;
                    // input path
                    Console.WriteLine("Введите имя файла в папке исполнимого файла консольного приложения (без указания расширения):");
                    string path = $@"{Console.ReadLine()}.csv";
                    theatres = CsvProcessing.Read(path);

                    theatres = CsvProcessing.SortByCapacity(theatres, false);
                    CsvProcessing.Print(theatres, "MainHallCapacity", "AdditionalHallCapacity");
                    CsvProcessing.Write(theatres, @"..\..\..\..\Output");

                    int command; // chosen command
                    Console.WriteLine("\n---------\nМеню:\n" +
                        "1. Произвести выборку по значению ChiefName\n" +
                        "2. Произвести выборку по значению AdmArea\n" +
                        "3. Отсортировать таблицу по значениям MainHallCapacity и AdditionalHallCapacity (по возрастанию)\n" +
                        "4. Отсортировать таблицу по значениям MainHallCapacity и AdditionalHallCapacity (по убыванию)\n" +
                        "5. Выйти из программы\n---------\n\n" +
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
                            Console.WriteLine("\nВведите значение выборки ChiefName:"); // Нижегородский район
                            string value = Console.ReadLine() + "";

                            theatres = CsvProcessing.Filter(theatres, "ChiefName", value);
                            CsvProcessing.Print(theatres, "ChiefName");

                            // cheking if no lines match the selection,
                            // meaning that new_lines[] contains only headers.
                            if (new_lines.Length == 2)
                            {
                                Console.WriteLine("Такой выборки не существует.");
                                throw new Exception("Kill program");
                            }
                            CsvProcessing.Print(new_lines, 4);
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
                            CsvProcessing.Print(new_lines, 9);
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
                            CsvProcessing.Print(new_lines, 5, 7);
                            break;

                        case 4:
                            new_lines = DataProcessing.SortByColumn("AvailableTransfer");
                            CsvProcessing.Print(new_lines, 8);
                            break;

                        case 5:
                            new_lines = DataProcessing.SortByColumn("YearOfComissioning");
                            CsvProcessing.Print(new_lines, 6);
                            break;

                        case 6:
                            break;

                    }

                    // Checking if a user decided to kill program.
                    if (new_lines == null) throw new Exception("Kill program");

                    Console.WriteLine("\n-------------\nДля сохранения данных нажмите ENTER.\nИначе нажмите любую другую клавишу.\n-------------");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("\nCSV-Файл будет сохранен в папке исполнимого файла консольного приложения.\nВведите желаемое имя файла:");
                        string file_name = Console.ReadLine() + ""; // file_name
                        while (true)
                        {
                            try
                            {
                                // if new_lines[] contains only one line (excluding headers), we use the first variation of overriden method Write()
                                if (new_lines.Length == 3) CsvProcessing.Write(new_lines[2], file_name + ".csv");
                                else
                                {
                                    CsvProcessing.Path = file_name + ".csv";
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
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    if (e.Message != "Kill program") Console.WriteLine("Возникла непредвиденная ошибка.");
                }


                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

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