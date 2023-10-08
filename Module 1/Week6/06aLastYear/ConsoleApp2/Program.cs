/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2
Программа получает на вход строку из латинских символов, пробелов и точек с запятой. Например: 
Let it be; All you need is love; Dizzy Miss Lizzy
Каждую подстроку, стоящую между точками с запятой преобразовать в аббревиатуру, 
сокращая каждое отдельное слово подстроки «до первой гласной» (гласная входит в сокращенную запись).
В аббревиатуре каждую первую букву отдельного слова  записать в верхнем регистре.
Результат вывести на экран, размещая аббревиатуры в столбик
 Дата:      08.10.2023
*/

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                Console.WriteLine("Введите строку, состоящую из латинских символов, пробелов и точек с запятой:");
                string str = Console.ReadLine(); // строка
                while (!Methods.Validate(str))
                {
                    Console.WriteLine("\nНеверный формат строки.");
                    Console.WriteLine("Введите строку, состоящую из латинских символов, пробелов и точек с запятой:");
                    str = Console.ReadLine(); // строка
                }

                string[] lines = Methods.ValidatedSplit(str, ';'); // массив подстрок
                Console.WriteLine("\nРезультат:");
                foreach (string line in lines)
                {
                    Console.WriteLine(Methods.Abbrevation(line));
                }



                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static string PrintAbbreviation(string str)
        {
            return "1";
        }
    }
}