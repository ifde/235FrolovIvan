using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using Main1Lib;

// Фролов Иван Григорьевич 
// Вариант XXX

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



                    Console.WriteLine("Выберите имя файла для создания объекта EllipseList (без указания расширения)");
                    string fileName;
                    EllipseList ellipses;
                    while (true)
                    {
                        fileName = Console.ReadLine() + "";
                        ellipses = new EllipseList(fileName);
                        if (ellipses.Ellipses.Length != 0) break;
                        Console.WriteLine("Возникла ошибка.\nПовторите попытку.");
                    }

                    do
                    {
                        Console.WriteLine("Меню:\n1 - Сохранить неупорядоченные данные\n" +
                        "2 - Сохранить упорядоченные по возрастанию меньшего диаметра данные + диапазон\n" +
                        "3 - Сохранить упорядоченные по возрастанию большего диаметра  данные");
                        int command;
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out command) && command >= 1 && command <= 3) break;
                            Console.WriteLine("Wrong input. Try again.");
                        }

                        double minn = 0, maxx = 0;
                        if (command == 2)
                        {
                            Console.WriteLine("Введите MIN:");
                            while(true)
                            {
                                if (double.TryParse(Console.ReadLine(), out minn) && minn > 0) break;
                                Console.WriteLine("Wrong input. Try again.");
                            }

                            Console.WriteLine("Введите MAX:");
                            while (true)
                            {
                                if (double.TryParse(Console.ReadLine(), out maxx) && maxx > 0 && maxx >= minn) break;
                                Console.WriteLine("Wrong input. Try again.");
                            }
                        }


                        string path = @"../../../../input/output.txt";
                        if (!File.Exists(path))
                        {
                            var fs = File.Create(path);
                            fs.Close();
                        }

                        var enumerator = command switch
                        {
                            1 => ellipses.Ellipses.AsEnumerable(),
                            2 => ellipses.GetIterator(1),
                            3 => ellipses.GetIterator(-1),
                            _ => throw new Exception()
                        };

                        string lines = "\n";
                        foreach (var rectangle in enumerator)
                        {
                            if (command == 2)
                            {
                                if (rectangle.MaxDiametr < minn || rectangle.MaxDiametr > maxx) continue;
                            }
                            lines += rectangle.ToString() + '\n';
                        }
                        File.AppendAllText(path, lines);

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