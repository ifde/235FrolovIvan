/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      КДЗ-2
 Дата:      25.11.2023
*/


using System.ComponentModel;
using System.Security.Principal;
using System.Windows.Markup;

using ClassLibrary1;

namespace ConsoleApp1
{
    internal class Program
    {

        /// <summary>
        /// Reads the lines of the file
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        static string[] ReadFile()
        {
            string[] values = new string[0]; // lines of the file

            Console.WriteLine("Введите имя TXT-файла, который лежит в папке исполнимого приложения.");

            // reading the file
            while (true)
            {
                try
                {
                    string name = Console.ReadLine(); // the name of the file
                    values = File.ReadAllLines(name + ".txt");
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Неверно задано имя файла. Повторите попытку.");
                    continue;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файла с таким именем не существует. Повторите попытку.");
                    continue;
                }
                catch (IOException)
                {
                    Console.WriteLine("Невозможно прочитать данные из файла.");
                    throw new Exception("Kill program.");
                }
            }

            return values;
        }

        /// <summary>
        /// Processes data and creates a list of strings to write to the output file
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        static List<string> DataProcessing(string[] values)
        {
            List<string> lines = new List<string>(); // lines to write to the output file

            try
            {
                foreach (string value in values)
                {
                    int n = int.Parse(value);
                    NumbJagged arr = new NumbJagged(n);
                    string[] tempLines = arr.AsString();

                    for (int i = 0; i < tempLines.Length; i++)
                    {
                        lines.Add(tempLines[i] + $"Количество возможных треугольников = {arr.TriangleNumber(i)}");
                    }
                    lines.Add("\n");
                }
            }
            catch (ArgumentException e) // catching an exeption thrown by the NumbJagged object
            {
                Console.WriteLine(e.Message);
                throw new Exception("Kill program.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат данных в файле.");
                throw new Exception("Kill program.");
            }

            return lines;
        }

       static void WriteFile(string[] lines)
       {
            // printing data to the console
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("Введите имя TXT-файла, в который хотите сохранить результат.");
            
            // writing to the file
            while(true)
            {
                try
                {
                    
                    File.WriteAllLines(Console.ReadLine() + ".txt", lines);
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Неверно задано имя файла. Повторите попытку.");
                    continue;
                }
                catch (IOException)
                {
                    Console.WriteLine("Невозможно записать данные в файл.");
                    throw new Exception("Kill program.");
                }
            }
            
            
        }

        static void Main(string[] args)
        {

            // repeat program
            do
            {
                Console.Clear();
                // handles all of the exceptions that kill program
                try
                {
                    string[] values = ReadFile();

                    List<string> lines = DataProcessing(values);

                    WriteFile(lines.ToArray());

                }
                catch (Exception e)
                {
                    if (e.Message != "Kill program.") Console.WriteLine("Возникла непредвиденная ошибка.");
                    Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
                    continue;
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}