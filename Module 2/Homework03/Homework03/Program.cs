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

                        if (int.TryParse(Console.ReadLine(), out command) && command >= 1 && command <= 5) break;
                        Console.WriteLine("Такой команды не существует. Повторите попытку.");
                    }

                    switch (command)
                    {
                        case 1:
                            Console.WriteLine("\nВведите значение выборки ChiefName:");
                            string chiefName;
                            while (true)
                            {
                                chiefName = Console.ReadLine() + "";
                                if (Console.ReadLine() + "" != "") break;
                                Console.WriteLine("Значение не может быть пустым. Повторите попытку.");
                            }

                            theatres = CsvProcessing.Filter(theatres, "ChiefName", chiefName);

                            // cheking if no theatres match the selection
                            if (theatres.Length == 0)
                            {
                                Console.WriteLine("Такой выборки не существует.");
                                throw new Exception("Kill program");
                            }
                            CsvProcessing.Print(theatres, "ChiefName");
                            break;

                        case 2:
                            Console.WriteLine("\nВведите значение выборки AdmArea:");
                            string admArea;
                            while (true)
                            {
                                admArea = Console.ReadLine() + "";
                                if (Console.ReadLine() + "" != "") break;
                                Console.WriteLine("Значение не может быть пустым. Повторите попытку.");
                            }

                            theatres = CsvProcessing.Filter(theatres, "AdmArea", admArea);

                            // cheking if no theatres match the selection
                            if (theatres.Length == 0)
                            {
                                Console.WriteLine("Такой выборки не существует.");
                                throw new Exception("Kill program");
                            }
                            CsvProcessing.Print(theatres, "AdmArea");
                            break;

                        case 3:
                            theatres = CsvProcessing.SortByCapacity(theatres, true);
                            CsvProcessing.Print(theatres, "MainHallCapacity", "AdditionalHallCapacity");
                            break;

                        case 4:
                            theatres = CsvProcessing.SortByCapacity(theatres, false);
                            CsvProcessing.Print(theatres, "MainHallCapacity", "AdditionalHallCapacity");
                            break;

                        case 5:
                            throw new Exception("Kill program");

                    }

                    Console.WriteLine("\n---------\nВыберите режим сохранения файла:\n" +
                        "1. Создание нового файла.\n" +
                        "2. Замена уже существующего файла.\n" +
                        "3. Добавление сохраняемых данных к содержимому уже существующего файла.");

                    // input command
                    while (true)
                    {

                        if (int.TryParse(Console.ReadLine(), out command) && command >= 1 && command <= 3) break;
                        Console.WriteLine("Такой команды не существует. Повторите попытку.");
                    }

                    Console.WriteLine("Введите имя файла, который лежит / будет создан в папке исполнимого файла консольного приложения. Расширение не указывайте.");
                    path = Console.ReadLine() + ".csv";

                    switch (command)
                    {

                        case 1:
                            CsvProcessing.Write(theatres, path, "Write");
                            break;

                        case 2:
                            if (!File.Exists(path))
                            {
                                Console.WriteLine("Файла с таким именем не существует.");
                                throw new Exception("Kill program");
                            }
                            CsvProcessing.Write(theatres, path, "Write");
                            break;

                        case 3:
                            if (!File.Exists(path))
                            {
                                Console.WriteLine("Файла с таким именем не существует.");
                                throw new Exception("Kill program");
                            }
                            CsvProcessing.Write(theatres, path, "Append");
                            break;

                    }
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.ParamName);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException)
                {
                    Console.WriteLine("Возникла ошибка при работе с файлом.");
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