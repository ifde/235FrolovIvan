/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      4
Определить вспомогательный метод для выделения из символьного массива подмассива, 
не содержащего конкретных символов, определяемых параметром типа string.  
 Дата:      09.10.2023
*/

using System.Runtime.InteropServices;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        /// <summary>
        /// Dыделения из символьного массива подмассива, 
        /// не содержащего конкретных символов, определяемых параметром типа string
        /// </summary>
        /// <param name="line"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        static char[] Row(char[] line, string model)
        {
            char[] res = new char[line.Length]; // итоговый массив
            int k = 0; // длина массива res 
            foreach (char ch in line)
            {
                bool flag = true; //флаг
                foreach (char restr in model)
                {
                    if (restr == ch)
                    {
                        flag = false;
                        break;
                    }
                }
                if (!flag) res[k++] = ch;
            }

            return res;

        }

    }
}