
namespace ConsoleApp2
{
    internal class Methods
    {
        /// <summary>
        /// Проверка, что строка состоит только из латинских символов и пробелов
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Validate(string str)
        {
            char[] temp = new char['z' - 'a' + 'Z' - 'A' + 4]; // временный массив латинских символов и пробела
            for (int i = 0; i < 'z' - 'a' + 1; i++)
            {
                temp[i] = (char)('a' + i);
            }
            for (int i = 0; i < 'Z' - 'A' + 1; i++)
            {
                temp[i + ('z' - 'a' + 1)] = (char)('A' + i);
            }
            temp[temp.Length - 2] = ' ';
            temp[temp.Length - 1] = ';';

            string alph = new string(temp); // строка латинских символов и пробела
            foreach (char ch in str)
            {
                if (!alph.Contains(ch))
                {
                    return false;
                }
            }
            return true;

        }

        /// <summary>
        /// Получение массива строк из строки, в которой подстроки связаны (или разделены) точками с запятой
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static string[] ValidatedSplit(string str, char ch)
        {
            return str.Split(ch, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Удаление из слова букв, размещенных после первой гласной
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Shorten(string str)
        {
            string vowels = "eyuoaiEYUOAI"; // стркоа гласных
            for (int i = 0; i < str.Length; i++)
            {
                if (vowels.Contains(str[i]) && i != str.Length - 1)
                {
                    str = str.Remove(i + 1);
                    break;
                }

            }

            return str;
        }
        /// <summary>
        /// Каждую строку преобразовать в аббревиатуру, 
        /// сокращая каждое отдельное слово подстроки «до первой гласной» (гласная входит в сокращенную запись). 
        /// В аббревиатуре каждую первую букву отдельного слова записать в верхнем регистре. 
        /// </summary>
        /// <param name="str">строка из слов</param>
        /// <returns></returns>
        public static string Abbrevation(string str)
        {
            string[] words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries); // массив слов из строки
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = Shorten(words[i]);
                FirstUpcase(ref words[i]);
            }
            return string.Join("", words);
        }

        /// <summary>
        /// Приведение первой буквы слова к верхнему регистру, а остальных -  к нижнему
        /// </summary>
        /// <param name="str"></param>
        public static void FirstUpcase(ref string str)
        {
            char[] chars = str.ToCharArray(); // создаем вспомогательный массив символов строки
            chars[0] = char.ToUpper(chars[0]);
            for (int i = 1; i < chars.Length; i++)
            {
                chars[i] = char.ToLower(chars[i]);

            }
            str = new string(chars);
        }
    }
}
