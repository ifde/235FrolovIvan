/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      КДЗ-1 (3 модуль)
Вариант:     8
Дата:        12.01.24
*/

using JsonLib;
using System.IO;

namespace MainProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // repeat program
            do
            {
                Console.Clear();

                try
                {

                    string path; // the path of the file
                    Customer[] customers; // a list of customers;
                    Menu1(out path, out customers);
                    Menu2(ref customers);
                    Menu3(ref customers, path);

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.ParamName);
                }
                catch (Exception e)
                {
                    if (e.Message != "Kill program") Console.WriteLine("Возникла непредвиденная ошибка.");
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }

        /// <summary>
        /// Menu1 for the main program.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="customers"></param>
        /// <exception cref="Exception"></exception>
        static void Menu1(out string path, out Customer[] customers)
        {
            int command;
            // printing menu
            Console.WriteLine("\n---------\nМеню:\n" +
                "1. Ввести данные через System.Console.\n" +
                "2. Предоставить путь к файлу для чтения данных.\n" +
                "3. Выйти из программы\n---------\n\n" +
                "Укажите номер пункта меню для запуска действия:");

            // input command
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out command) && command >= 1 && command <= 3) break;
                Console.WriteLine("Такой команды не существует. Повторите попытку.");
            }

            customers = new Customer[0]; // an array of customers
            path = null; // the path of the file.
            switch (command)
            {
                case 1:
                    customers = JsonParser.ReadJson();
                    break;
                case 2:
                    // inputting file and changing Stream
                    Console.WriteLine("Введите имя JSON-файла в папке исполнимого файла консольного приложения (без указания расширения):");
                    path = $@"{Console.ReadLine()}.json";
                    Console.SetIn(new StreamReader(path));

                    customers = JsonParser.ReadJson();
                    Console.SetIn(new StreamReader(Console.OpenStandardInput())); // restoring stream;
                    break;
                case 3:
                    throw new Exception("Kill program");
            }
        }

        /// <summary>
        /// Menu2 for the main program.
        /// </summary>
        /// <param name="customers"></param>
        /// <exception cref="Exception"></exception>
        static void Menu2(ref Customer[] customers)
        {
            int command;
            Console.WriteLine("\n---------\nМеню:\n" +
                       "1. Отфильтровать данные по одному из полей.\n" +
                       "2. Отсортировать данные по одному из полей.\n" +
                       "3. Выйти из программы\n---------\n\n" +
                       "Укажите номер пункта меню для запуска действия:");

            // input command
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out command) && command >= 1 && command <= 3) break;
                Console.WriteLine("Такой команды не существует. Повторите попытку.");
            }

            switch (command)
            {

                case 1:
                    Console.WriteLine("Введите название поля без кавычек.\nВарианты: customer_id, name, email, age, city, is_premium, orders");
                    string field = Console.ReadLine() + ""; // given field

                    if (field == "orders") Console.WriteLine("Введите массив в виде \"a, b, c\". Дробные числа вводите с точностью ровно два знака. Разделитель - точка.");
                    else Console.WriteLine("Выберите значение поля:");
                    string value = Console.ReadLine() + ""; // value of the given field

                    customers = ArrayMethods.Filter(customers, field, value);
                    break;
                case 2:
                    Console.WriteLine("Введите название поля без кавычек.\nВарианты: customer_id, name, email, age, city");
                    string field1 = Console.ReadLine() + ""; // given field

                    Console.WriteLine("1 - по возрастанию. (-1) - по убыванию");
                    // input command
                    while (true)
                    {

                        if (int.TryParse(Console.ReadLine(), out command) && (command == 1 || command == -1)) break;
                        Console.WriteLine("Такой команды не существует. Повторите попытку.");
                    }

                    ArrayMethods.Sort(customers, field1, command);
                    break;
                case 3:
                    throw new Exception("Kill program");
            }
        }

        /// <summary>
        /// Menu3 for the main program.
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="path"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        static void Menu3(ref Customer[] customers, string path)
        {
            int command;
            Console.WriteLine("\n---------\nМеню:\n" +
                      "1. Вывести данные в консоль.\n" +
                      "2. Сохранить данные в файл.\n" +
                      "3. Выйти из программы\n---------\n\n" +
                      "Укажите номер пункта меню для запуска действия:");

            // input command
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out command) && command >= 1 && command <= 3) break;
                Console.WriteLine("Такой команды не существует. Повторите попытку.");
            }

            switch (command)
            {
                case 1:
                    JsonParser.WriteJson(customers);
                    break;
                case 2:
                    Console.WriteLine("1 - перезаписать исходный файл. 2 - создать новый файл.");
                    // input command
                    while (true)
                    {

                        if (int.TryParse(Console.ReadLine(), out command) && command >= 1 && command <= 2) break;
                        Console.WriteLine("Такой команды не существует. Повторите попытку.");
                    }

                    switch (command)
                    {
                        case 1:
                            if (path == null) throw new ArgumentException("Исходного файла на существует.");

                            Console.SetOut(new StreamWriter(path));
                            JsonParser.WriteJson(customers);
                            Console.SetOut(new StreamWriter(Console.OpenStandardOutput())); // restoring stream;
                            break;
                        case 2:
                            Console.WriteLine("Введите название файла без указания расширения.\nОн будет сохранен в папке в папке исполнимого файла консольного приложения.");
                            path = Console.ReadLine() + "";
                            Console.SetOut(new StreamWriter(path));
                            JsonParser.WriteJson(customers);
                            Console.SetOut(new StreamWriter(Console.OpenStandardOutput())); // restoring stream;
                            break;
                    }

                    break;
                case 3:
                    throw new Exception("Kill program");
            }
        }
    }
}