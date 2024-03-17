using System.Globalization;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.RegularExpressions;
using Main1Lib;
using Main3Lib;

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



                    Console.WriteLine("Выберите имя файла для создания объекта CircleList (без указания расширения)");
                    string fileName;
                    CircleList circles;
                    while (true)
                    {
                        fileName = Console.ReadLine() + "";
                        circles = new CircleList(fileName);
                        if (circles.Circles.Length != 0) break;
                        Console.WriteLine("Возникла ошибка.\nПовторите попытку.");
                    }

                    do
                    {
                        Console.WriteLine("Меню:\n1 - Сохранить упорядоченные по возрастанию данные\n" +
                        "2 - Сохранить упорядоченные по возрастанию данныее + диапазон\n" +
                        "3 - Сохранить упорядоченные по убыванию данные\n" +
                        "4 - Получить все окружности по убыванию радиуса, у которых площадь больше 15\n" +
                        "5 - Получить все окружности по возрастанию радиуса, у которых радиус меньше 4\n");
                        int command;
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out command) && command >= 1 && command <= 5) break;
                            Console.WriteLine("Wrong input. Try again.");
                        }

                        double minn = 0, maxx = 0;
                        if (command == 2)
                        {
                            Console.WriteLine("Введите MIN:");
                            while (true)
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


                        string path = @"../../../../inputMain3/output.txt";
                        MyFile.CreateFile(path);

                        var enumerator = command switch
                        {
                            1 => circles.GetIterator(1),
                            2 => circles.GetIterator(1),
                            3 => circles.GetIterator(-1),
                            4 => from c in circles
                                 orderby c.R descending
                                 where c.R * c.R * Math.PI > 15
                                 select c,
                            5 => from c in circles
                                 orderby c.R ascending
                                 where c.R < 4
                                 select c,
                            _ => throw new Exception()
                        };

                        
                        if (command == 4 || command == 5)
                        {
                            foreach (var circle in enumerator) Console.WriteLine(circle);
                        }
                        else
                        {
                            string lines = "\n";
                            foreach (var circle in enumerator)
                            {
                                if (command == 2)
                                {
                                    if (circle.R < minn || circle.R > maxx) continue;
                                }
                                lines += circle.ToString() + '\n';
                            }
                            MyFile.AppendAllText(path, lines);

                            Console.WriteLine("Сохраненные данные:");
                            Console.WriteLine(MyFile.ReadAllText(path));
                        }

                        Console.WriteLine("Press ENTER to go again.\nPress any other key to finish program.");
                    }
                    while (Console.ReadKey().Key == ConsoleKey.Enter);


                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine("Ошибка при работе с файлом.");
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