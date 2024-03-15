using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using TextFile;

namespace Main
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

                    

                    Console.WriteLine("Выберите имя файла для создания объекта RectangleList (без указания расширения)");
                    string fileName;
                    RectangleList rectangles;
                    while (true)
                    {
                        fileName = Console.ReadLine() + "";
                        rectangles = new RectangleList(fileName);
                        if (rectangles.Rectangles.Length != 0) break;
                        Console.WriteLine("Возникла ошибка.\nПовторите попытку.");
                    }

                    do
                    {
                        Console.WriteLine("Меню:\n1 - Сохранить неупорядоченные данные\n" +
                        "2 - Сохранить упорядоченные по возрастанию данные\n" +
                        "3 - Сохранить упорядоченные по убыванию данные");
                        int command;
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out command) && command >= 1 && command <= 3) break;
                            Console.WriteLine("Wrong input. Try again.");
                        }

                        List<int> numbers = new List<int>();
                        foreach (string temp in Directory.EnumerateFiles(@"../../../../data/"))
                        {
                            var match = Regex.Match(temp, @"(?<=/output-)\d*(?=\.txt)");
                            string value = match.Value;
                            if (string.IsNullOrEmpty(value)) continue;
                            int number;
                            int.TryParse(value, out number);
                            if (number != 0) numbers.Add(number);

                        }
                        numbers.Sort();

                        string path;
                        if (numbers.Count == 0) path = @"../../../../data/output-1.txt";
                        else path = @"../../../../data/output-" + (numbers.Last() + 1) + ".txt";

                        var enumerator = command switch
                        {
                            1 => rectangles.Rectangles.AsEnumerable(),
                            2 => rectangles.GetIterator(1),
                            3 => rectangles.GetIterator(-1),
                            _ => throw new Exception()
                        };

                        string lines = "";
                        foreach (var rectangle in enumerator)
                        {
                            lines += rectangle.ToString() + '\n';
                        }
                        File.WriteAllText(path, lines);

                        Console.WriteLine("Сохраненные данные:");
                        Console.WriteLine(File.ReadAllText(path));

                        Console.WriteLine("Press ENTER to go again.\nPress any other key to finish program.");
                    }
                    while (Console.ReadKey().Key == ConsoleKey.Enter);

                    
                }
                catch (ArgumentException e)
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