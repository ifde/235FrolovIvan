using System.ComponentModel.Design;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Xml;
using Task03Lib;

namespace Task03
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
                    List<MyColor> colors = new List<MyColor>();
                    using (StreamReader sr = new StreamReader(@"../../../css-color-names.json"))
                    {
                        string? line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line == "{" || line == "}") continue;
                            string color_name = "";
                            foreach (Match match in Regex.Matches(line, @"(?<="")[^"":]*(?="")"))
                            {
                                string value = match.Value;
                                if (value[0] != '#') color_name = value; // reading color_name
                                else
                                {
                                    colors.Add(new MyColor(color_name, MyColor.StringToColor(value)));
                                }
                            }
                        }
                    }

                    foreach (var color in  colors)
                    {

                        Console.ForegroundColor = FromColor(color.GetColor);
                        Console.WriteLine(color.Name);
                    }
                    Console.ResetColor();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.ParamName);
                }
                catch (Exception)
                {
                    Console.WriteLine("Возникла непредвиденная ошибка.");
                }


                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static ConsoleColor FromColor(Color c)
        {
            int index = (c.R > 128 | c.G > 128 | c.B > 128) ? 8 : 0; // Bright bit
            index |= (c.R > 64) ? 4 : 0; // Red bit
            index |= (c.G > 64) ? 2 : 0; // Green bit
            index |= (c.B > 64) ? 1 : 0; // Blue bit
            return (ConsoleColor)index;
        }
    }
}