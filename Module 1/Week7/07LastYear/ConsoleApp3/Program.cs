/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      3

Написать программу, которая:
 Генерирует случайным образом 6 предложений длиной от 20 до 50 символов (алфавит – все строчные символы кириллицы), заканчивающихся точкой.
 Записывает предложения построчно (каждое предложение на отдельной строке файла) в текстовый файл dialog.txt в кодировке UTF-8, расположенный в папке с исполняемым файлом.
 Выводит на экран то, что было записано в файл изначально.
 Открывает полученный файл и выводит на экран построчно все предложения из него, удаляя точки в конце предложения.

 Дата:       12.10.2023
*/

using System.Text;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] sentences = GenerateSentences(6);
                File.WriteAllLines(@"..\..\..\dialog.txt", sentences, encoding: Encoding.UTF8);
                // выводим данные, записанные в файл
                Console.WriteLine("Данные, записанные в файл:");
                foreach (string sentence in sentences)
                {
                    Console.WriteLine(sentence);
                }

                Console.WriteLine("\nУдалили точки на концах предложений:");
                foreach (string file in File.ReadAllLines(@"..\..\..\dialog.txt"))
                {
                    Console.WriteLine(file.Trim()[..^1]);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при работе с файлом");
            }
            
        }

        /// <summary>
        /// Создает массив предложений длиной от 20 до 50 символов (алфавит – все строчные символы кириллицы), заканчивающихся точкой.
        /// </summary>
        /// <param name="n">размер массива</param>
        /// <returns>Возращает полученный массив</returns>
        static string[] GenerateSentences(int n)
        {
            string[] sentences = new string[n];
            Random rand = new Random(); // генерация случайных чисел
            for (int i = 0; i < n; i++)
            {
                char[] symbols = new char[rand.Next(20, 51)]; // массив символов в предложении
                for (int j = 0; j < symbols.Length - 1; j++)
                {
                    symbols[j] = (char)('а' + rand.Next(0, 'я' - 'а' + 1));
                }
                symbols[symbols.Length - 1] = '.';
                sentences[i] = new string(symbols);
            }
            return sentences;
        }
    }
}