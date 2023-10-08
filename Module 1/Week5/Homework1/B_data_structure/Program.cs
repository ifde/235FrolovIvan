/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2
  Дата:      05.10.2023
*/

using System.Text.RegularExpressions;

namespace B_data_structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                double[][] b; // структура данных B

                // Введите название TXT-файла заданного формата, который вы создали в проекте A_data_structure.
                Console.WriteLine("Введите название TXT-файла заданного формата, который вы создали в проекте A_data_structure");
                string path = CreateFile(Console.ReadLine());
                if (!File.Exists(path))
                {
                    Console.WriteLine("Такого файла нет");
                }
                else
                {
                    if (!StringToArray(out b, File.ReadAllText(path)))
                    {
                        Console.WriteLine("Неверный формат данных в файле");
                    }
                    else
                    {
                        int k; // сдвиг
                        // Ввод k с клавиатуры
                        Console.WriteLine("Введите неотрицательный сдвиг:");
                        while (!int.TryParse(Console.ReadLine(), out k) || k < 0)
                        {
                            Console.WriteLine("Wrong Input");
                            Console.WriteLine("Введите неотрицательный сдвиг:");
                        }

                        Console.WriteLine("\nДанные до сдвига:");
                        Console.WriteLine(ArrayToString(b)); // до изменений

                        ChangeArr(b, k);

                        Console.WriteLine("\nДанные после сдвига:");
                        Console.WriteLine(ArrayToString(b)); // после изменений
                    }

                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Путь к TXT-файлу в текущей дериктории с названием, переданным в качестве аргумента
        /// </summary>
        /// <param name="file_name"></param>
        /// <returns>Полный путь к файлу</returns>
        static string CreateFile(string file_name)
        {
            if (Regex.Match(file_name, @"^\w+$").Success) // проверяем, что название файла состоит из [a_zA_Z0_9]
            {
                return Directory.GetCurrentDirectory() + @"..\..\..\..\..\A_data_structure\" /*переходим в директорию проекта A_data_structure*/+ file_name + ".txt";
            }
            return null; // возвращаем null, если имя файла указано неверно
        }

        /// <summary>
        /// Конвертирует строку в массив
        /// </summary>
        /// <param name="b"></param>
        /// <param name="text"></param>
        /// <returns>Если конвертация невозможна, возвращает false. Иначе - true</returns>
        static bool StringToArray(out double[][] b, string text)
        {
            text += " ";
            string[] rows = text.Split("; ")[..^1]; // разбиваем исходный текст на строки для массива
            b = new double[rows.Length][];
            for (int i = 0; i < rows.Length; i++) // пробегаем по всем строкам
            {
                string[] elems = rows[i].Split(' '); // массив элементов каждой из строк
                b[i] = new double[elems.Length];
                for (int j = 0; j < elems.Length; j++) // пробегаем по всем элементам каждой из строк
                {
                    if (!double.TryParse(elems[j], out b[i][j])) // если данные введены неверно, то возвращаем false
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        /// <summary>
        /// Обрабатывает элементы массива по правилу
        /// </summary>
        /// <param name="max_len">максимальная длина строки в зубчатов массиве b</param>
        static void ChangeArr(double[][] b, int k)
        {
            int max_len = 0; // максимальная длина строки в структуре B
            foreach (double[] row in b)
            {
                if (max_len < row.Length) max_len = row.Length;
            }
            // заполняем массив B нулями до прямоугольного вида
            for (int i = 0; i < b.Length; i++)
            {
                Array.Resize(ref b[i], max_len);
            }

            // сдвигаем элементы массива
            foreach (double[] row in b)
            {
                double[] temp = (double[])row.Clone(); // создаем копию строки
                for (int i = 0; i < max_len; i++)
                {
                    row[(i + k % max_len) % max_len] = temp[i];
                }
            }
        }

        /// <summary>
        /// Конвертирует двумерный массив строки для вывода
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Возращает эту строку</returns>
        static string ArrayToString(double[][] a)
        {
            string res = "";// итоговая строка
            foreach (double[] elem in a)
            {
                res += string.Join(' ', elem) + '\n';
            }
            return res;
        }
    }
}