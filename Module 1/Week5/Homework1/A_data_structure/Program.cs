/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1
  Дата:      05.10.2023
*/

using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace A_data_structure
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // повтор решения 
            do
            {
                Console.Clear();

                double[,] a; // двумерный массив N * M вещественных значений
                int n, m; // размеры двумерного массива

                // Ввод n с клавиатуры
                Console.WriteLine("Введите число строк двумерного массива A:");
                while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n >= 16)
                {
                    Console.WriteLine("Wrong Input");
                    Console.WriteLine("Введите число строк двумерного массива A:");
                }

                // Ввод m с клавиатуры
                Console.WriteLine("Введите число стобцов двумерного массива A:");
                while (!int.TryParse(Console.ReadLine(), out m) || m <= 0 || m >= 11)
                {
                    Console.WriteLine("Wrong Input");
                    Console.WriteLine("Введите число стобцов двумерного массива A:");
                }

                InitializeArr(out a, n, m);

                string path;
                // Ввод имени файла. При некорректном введенном названии запрашиваем ввод повторно.
                Console.WriteLine("Введите имя txt файла, состоящее только из цифр и латинских букв");
                path = CreateFile(Console.ReadLine());
                while (path == null)
                {
                    Console.WriteLine("Неверное название файла. Попробуйте еще раз");
                    path = CreateFile(Console.ReadLine());
                }

                File.WriteAllText(path, ArrayToString(a));

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Инициализирует массив и заполняет его по правилу
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        static void InitializeArr(out double[,] a, int n, int m)
        {
            a = new double[n, m];
            int cnt = 1; // счетчик
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = (double)(2 * cnt + 10) / (3 * cnt - 10);
                    cnt++;
                }
            }
        }

        /// <summary>
        /// Путь к TXT-файлу в текущей  директории с названием, переданным в качестве аргумента
        /// </summary>
        /// <param name="file_name"></param>
        /// <returns>Полный путь к файлу. Null, если имя файла указано неверно</returns>
        static string CreateFile(string file_name)
        {
            string path = @"..\..\..\" /*переходим в директорию проекта*/ + file_name + ".txt";
            try
            {
                File.Create(path).Close();
            }
            catch
            {
                return null;
            }
            return path;

        }

        /// <summary>
        /// Конвертирует двумерный массив в строку
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Возращает эту строку</returns>
        static string ArrayToString(double[,] a)
        {
            string res = "";// итоговая строка
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (j == a.GetLength(1) - 1)
                    {
                        // после последнего элемента строки ставим точку с запятой
                        if (i == a.GetLength(0) - 1) res += $"{a[i, j]:f2};"; // удаляем последний пробел просле двоеточия, если элемент самый последний
                        else res += $"{a[i, j]:f2}; ";
                    } 
                    else res += $"{a[i, j]:f2} "; // иначе ставим пробел
                }
            }
            return res;
        }
    }
}