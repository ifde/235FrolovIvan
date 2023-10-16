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

                // Читаем данные из TXT-файла заданного формата, который был создан в проекте A_data_structure.

                Console.WriteLine("Введите название TXT-файла заданного формата, который вы создали в проекте A_data_structure");
                string path = CreatePath(Console.ReadLine());
                try
                {
                    StringToArray(out b, File.ReadAllText(path));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Введено некорректное название файла.");
                    Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Нарушен формат в файле с данными.");
                    Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
                    continue;
                }
                catch (IOException)
                {
                    Console.WriteLine("Файл не обнаружен на диске / не открывается.");
                    Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine("Возникла непредвиденная ошибка.");
                    Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
                    continue;
                }

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

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Путь к TXT-файлу директории проекта A_data_structure с названием, переданным в качестве аргумента
        /// </summary>
        /// <param name="file_name"></param>
        /// <returns>Полный путь к файлу</returns>
        static string CreatePath(string file_name)
        {
            return @"..\..\..\..\A_data_structure\" /*переходим в директорию проекта A_data_structure*/+ file_name + ".txt";
        }

        /// <summary>
        /// Конвертирует строку в массив
        /// </summary>
        /// <param name="b"></param>
        /// <param name="text"></param>
        static void StringToArray(out double[][] b, string text)
        {
            text += " ";
            string[] rows = text.Split("; ")[..^1]; // разбиваем исходный текст на строки для массива
            b = new double[rows.Length][];

            int max_len = 0; // максимальная длина строки в массиве

            for (int i = 0; i < rows.Length; i++) // пробегаем по всем строкам
            {
                string[] elems = rows[i].Split(' '); // массив элементов каждой из строк
                b[i] = new double[elems.Length];
                for (int j = 0; j < elems.Length; j++) // пробегаем по всем элементам каждой из строк
                {
                    b[i][j] = double.Parse(elems[j]); // если данные введены неверно, то поймаем ошибку в Main();
                }
                if (max_len < elems.Length) max_len = elems.Length; // вычисляем максимальную длину строки
            }

            // заполняем массив B нулями до прямоугольного вида
            for (int i = 0; i < b.Length; i++)
            {
                Array.Resize(ref b[i], max_len);
            }

        }

        /// <summary>
        /// Обрабатывает элементы массива по правилу
        /// </summary>
        /// <param name="max_len">максимальная длина строки в зубчатов массиве b</param>
        static void ChangeArr(double[][] b, int k)
        {

            // сдвигаем элементы массива
            foreach (double[] row in b)
            {
                double[] temp = (double[])row.Clone(); // создаем копию строки
                for (int i = 0; i < row.Length; i++)
                {
                    row[(i + k % row.Length) % row.Length] = temp[i]; // выполняем сдвиг
                }
            }
        }

        /// <summary>
        /// Конвертирует двумерный массив в строку для вывода
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Возращает эту строку</returns>
        static string ArrayToString(double[][] a)
        {
            string res = ""; // итоговая строка

            foreach (double[] elem in a)
            {
                res += string.Join(' ', elem) + '\n';
            }
            return res;
        }
    }
}