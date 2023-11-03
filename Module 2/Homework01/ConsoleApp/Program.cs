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

                //string path = "";

                // input path
                Console.WriteLine("Введите абсолютный путь к файлу с CSV-данными:");
                //string input = Console.ReadLine();
                //while (input == null)
                //{
                //    Console.WriteLine("Your input is null. Try again.");
                //    input = Console.ReadLine();
                //}
                //path = input;

                CsvProcessing.path = Console.ReadLine();

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

                // main program
                try
                {
                    CsvProcessing.Read();
                    switch (command)
                    {
                        case 1:
                            if (DataProcessing.GetSelectedFields("District").Length == 0)
                            {
                                Console.WriteLine("Такой выборки не существует.");
                                break;
                            }
                            foreach (string line in DataProcessing.GetSelectedFields("District"))
                            {
                                Console.WriteLine(line);
                            }
                            break;

                        case 2:
                            if (DataProcessing.GetSelectedFields("CarCapacity").Length == 0)
                            {
                                Console.WriteLine("Такой выборки не существует.");
                                break;
                            }
                            foreach (string line in DataProcessing.GetSelectedFields("CarCapacity"))
                            {
                                Console.WriteLine(line);
                            }
                            break;

                        case 3:
                            if (DataProcessing.GetSelectedFields("Status", "NearStation").Length == 0)
                            {
                                Console.WriteLine("Такой выборки не существует.");
                                break;
                            }
                            foreach (string line in DataProcessing.GetSelectedFields("Status", "NearStation"))
                            {
                                Console.WriteLine(line);
                            }
                            break;

                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Ошибка при чтении файла.");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Неверный путь к файлу.");
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