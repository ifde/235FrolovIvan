/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1
 Дата:      08.10.2023
*/

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                int n; // длина строки
                Console.WriteLine("Введите длину строки:");
                while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите длину строки:");
                }
                string str = CreateString(n, '1', '9');

                Console.WriteLine("\nИсходная строка из десятичных цифр:");
                Console.WriteLine(str);
                MoveOff(ref str, "2468");
                Console.WriteLine("\nСтрока, полученная после удаления всех четных цифр:");
                Console.WriteLine(str);

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Cоздание строки заданной длины из символов, случайно выбираемых из указанного диапазона
        /// </summary>
        /// <param name="n"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string CreateString(int n, char begin, char end)
        {
            Random rand = new Random(); // генерация случайных чисел
            char[] chars = new char[n]; // масисв символов
            for (int i = 0; i < n; i++)
            {
                chars[i] = (char)rand.Next(begin, end + 1);
            }
            string a = new string(chars);
            return a;
        }

        /// <summary>
        /// Удаляет из строки все символы другой строки
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void MoveOff(ref string a, string b)
        {
            if (a == null || a.Length == 0) return;
            if (b == null) return;

            foreach (char c in b)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (c == a[i]) a = a.Remove(i--, 1);
                }
            }
        }
    }
}