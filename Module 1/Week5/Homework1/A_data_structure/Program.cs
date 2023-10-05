/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1
  Дата:      05.10.2023
*/

namespace A_data_structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            string directory = Directory.GetCurrentDirectory();
            Directory.GetParent(Directory.GetParent(Directory.GetParent(directory)));
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(Environment.CurrentDirectory);



            //string path;
            //// Ввод имени файла. При некорректном введенном названии запрашиваем ввод повторно.
            //Console.WriteLine("Введите имя txt файла без точек");
            //path = CreateFile(Console.ReadLine());
            //while (path == null)
            //{
            //    Console.WriteLine("Неверное название файла. Попробуйте еще раз");
            //    path = CreateFile(Console.ReadLine());
            //}

            //File.WriteAllText(path, ArrayToString(a));

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
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = (double)(2 * cnt + 10) / (3 * cnt - 10);
                    cnt++;
                }
            }
        }

        /// <summary>
        /// Путь к TXT-файлу в текущей дериктории с названием, переданным в качестве аргумента
        /// </summary>
        /// <param name="file_name"></param>
        /// <returns>Полный путь к файлу</returns>
        static string CreateFile (string file_name)
        {
            if (file_name == null) return null; // возвращаем null, если имя файла не задано пользователем
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                file_name = file_name.Replace(c.ToString(), ""); // удаляем все некорректные элементы
            }
            return Path.Combine(Directory.GetCurrentDirectory(), file_name + ".txt");
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
                    if (j == a.GetLength(1) - 1) res += $"{a[i, j],2}; "; // после последнего элемента строки ставим точку с запятой
                    else res += $"{a[i, j],2} "; // иначе ставим пробел
                }
            }

            return res;
        }
    }
}