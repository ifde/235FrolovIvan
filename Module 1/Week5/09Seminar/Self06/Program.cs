/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self06
        //Дана строка, среди символов которой
        //есть одна открывающаяся и
        //одна закрывающаяся скобка. Вывести на экран все символы, 
        //расположенные внутри этих скобок подсчитать их кол-во.
  Дата:      06.10.2023
*/



namespace Self06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();
                int left, right; // индекс соотвественно левой и правой скобки в строке 

                Console.WriteLine("Введите строку, содержащую  одну открывающуюся " +
                "и одну закрывающуюся скобку:");
                string s = Console.ReadLine(); // вводимая пользователем строка,
                                               // содержащая  одну открывающуюся и
                                               // одну закрывающуюся скобку
                while (!CheckString(s, out left, out right))
                {
                    Console.WriteLine("\nСтрока имеет неверный формат. Повторите ввод: ");
                    s = Console.ReadLine();
                }
                Console.WriteLine("\nПодсторка исходной строки между скобок:");
                Console.WriteLine($"{s[(left + 1)..right]}");
                Console.WriteLine($"\nЕе длина равна {right - left - 1}");

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            
        }

        /// <summary>
        /// Проверка, что в строке есть есть одна открывающаяся и
        /// одна закрывающаяся скобка
        /// </summary>
        /// <param name="s"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        static bool CheckString(string s, out int left, out int right)
        {
            left = s.Length;
            right = -1;
            string sub_s = ""; // подстрока исходной строки между скобок

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') left = i;
                if (s[i] == ')')
                {
                    right = i;
                    break;
                }
            }

            if (left == s.Length || right == -1)
            {
                return false;
            }
            return true;

        }
    }
}