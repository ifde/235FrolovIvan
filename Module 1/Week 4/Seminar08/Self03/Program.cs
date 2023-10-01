/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      Self03
   Дата:     30.09.2023
*/

namespace Self03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения
            do
            {
                Console.Clear();

                int shiftCount; // сдвиг
                char ch; // символ

                Console.WriteLine("Внимание! Буквы 'ё' нет в русском алфавите");
                //выводим русский алфавит, чтобы показать, что в нем нет буквы 'ё'
                for(char i = 'а'; i < 'я'; i++) {
                    Console.Write($"{i}, ");
                }
                Console.Write("я\n\n");

                // вводим из консоли символ
                Console.WriteLine("Введите символ:");
                while (!char.TryParse(Console.ReadLine(), out ch))
                {
                    Console.WriteLine("Неверное значение. Повторите ввод");
                    Console.WriteLine("Введите символ:");
                }

                // вводим из консоли сдвиг
                Console.WriteLine("Введите сдвиг:");
                while (!int.TryParse(Console.ReadLine(), out shiftCount))
                {
                    Console.WriteLine("Неверное значение. Повторите ввод");
                    Console.WriteLine("Введите сдвиг:");
                }

                if (Shift(shiftCount, ref ch)) {
                    Console.WriteLine($"Циклически сдвинутый символ: {ch}");
                } else
                {
                    Console.WriteLine($"Циклически сдвинутый символ: {ch}");
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Циклический сдвиг символа русского или английского алфавита
        /// </summary>
        /// <param name="shiftCount"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static bool Shift(int shiftCount, ref char ch)
        {
            // если символ не входит в русский или англйиский алфавит, то возвращаем false
            if (!(ch >= 'a' && ch <= 'z' ||
                ch >= 'A' && ch <= 'Z' ||
                ch >= 'а' && ch <= 'я' ||
                ch >= 'А' && ch <= 'Я'))
            {
                return false;
            }

            int ru_len = 'я' - 'а' + 1; // длина русского алфавита
            int eng_len = 'z' - 'a' + 1; // длина английского алфавита
            ch = ch switch
            {
                >= 'a' and <= 'z' => (char)('a' + ((ch - 'a') /*начинаем отсчет символов с нуля*/
                    + shiftCount % eng_len /*прибаляем значимый сдвиг*/
                    + eng_len /*избавляемся от возможных отрицательных индексов*/)
                    % eng_len /*избавляемся от возможного переполнения*/),

                >= 'A' and <= 'Z' => (char)('A' + ((ch - 'A') /*начинаем отсчет символов с нуля*/
                    + shiftCount % eng_len /*прибаляем значимый сдвиг*/
                    + eng_len /*избавляемся от возможных отрицательных индексов*/)
                    % eng_len /*избавляемся от возможного переполнения*/),

                >= 'а' and <= 'я' => (char)('а' + ((ch - 'а') /*начинаем отсчет символов с нуля*/
                + shiftCount % ru_len /*прибаляем значимый сдвиг*/
                + ru_len /*избавляемся от возможных отрицательных индексов*/)
                % ru_len /*избавляемся от возможного переполнения*/),

                >= 'А' and <= 'Я' => (char)('А' + ((ch - 'А') /*начинаем отсчет символов с нуля*/
                    + shiftCount % ru_len /*прибаляем значимый сдвиг*/
                    + ru_len /*избавляемся от возможных отрицательных индексов*/)
                    % ru_len /*избавляемся от возможного переполнения*/),

                _ => ch
            };

            return true;
        }
    }
}