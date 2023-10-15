/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      DIY01

Во всех задачах данные для массивов получить из текстового файла input.txt, результирующие массивы также сохранять в текстовый файл output.txt.

По массиву A целых чисел со значениями из диапазона [-10;10] создать массив булевских значений L. 
Количество элементов в массивах совпадает. 
На местах положительных элементов в массиве A в массиве L стоят значения True, на месте отрицательных – False. 


 Дата:       12.10.2023
*/

using System.Text;

namespace DIY01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                // create and fill an araay with randon numbers in [-10; 10]
                int[] a;

                // Read from input.txt
                while(true)
                {
                    try
                    {
                        a = StringToArray(File.ReadAllText(@"..\..\..\input.txt"));
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ошибка при работе с фалом");
                    }
                }

                // create and fill a boolean array L
                bool[] l = new bool[a.Length];
                for (int i = 0; i < l.Length; i++)
                {
                    if (a[i] >= 0) l[i] = true;
                    else l[i] = false;
                }

                while (true)
                {
                    try
                    {
                        File.WriteAllText(@"..\..\..\output.txt", BoolArrayToString(l));
                        Console.WriteLine("Программа выполнена успешно!");
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ошибка при работе с фалом");
                    }
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Convert an boolean array into a string, 
        /// where true = 1, false = 0
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static string BoolArrayToString(bool[] l)
        {
            StringBuilder res = new StringBuilder();
            foreach (bool a in l)
            {
                if (a) res.Append("1 ");
                else res.Append("0 ");
            }
            return res.ToString();
        }

        /// <summary>
        /// Convert a string into an array
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static int[] StringToArray(string s)
        {
            string[] temp = s.Split(' ', StringSplitOptions.RemoveEmptyEntries); // a temporary array
            int[] res = new int[temp.Length]; // method output

            for (int i = 0; i <  temp.Length; i++)
            {
                res[i] = int.Parse(temp[i]); // if an Execption is throwns here, we'll catch it in Main()
            }
            return res;
        }
    }
}