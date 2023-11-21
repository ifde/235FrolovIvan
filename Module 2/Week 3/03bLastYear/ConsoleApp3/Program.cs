/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      3
 Дата:       20.11.2023
*/

using MyLib;
using System;
using System.Data;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag;
            MyString str;
            int n;
            char start, finish, ch;
            int mode;
            MyString[] arr = new MyString[10];
            do
            {
                flag = false;
                try
                {
                    Console.WriteLine("Нажмите 1, чтобы создать строку из латинских символов.");
                    Console.WriteLine("Нажмите 2, чтобы создать строку из кириллических символов.");
                    mode = int.Parse(Console.ReadLine());
                    if (mode != 1 && mode != 2) throw new ArgumentException();

                    Console.Write("Введите длину строки: ");
                    n = int.Parse(Console.ReadLine());
                    Console.Write("Введите минимально возможную букву в строке: ");
                    start = char.Parse(Console.ReadLine());
                    Console.Write("Введите максимально возможную букву в строке: ");
                    finish = char.Parse(Console.ReadLine());
                    Console.Write(Environment.NewLine);

                    str = mode == 2 ? new RusString(start, finish, n) : new LatString(start, finish, n);

                    Console.WriteLine(str);
                    if (str.isPlindrom) Console.WriteLine("Строка является палиндромом!");
                    else Console.WriteLine("Строка НЕ является палиндромом!");
                    Console.Write(Environment.NewLine);

                    do
                    {
                        Console.WriteLine("Введите любой символ.");
                        ch = char.Parse(Console.ReadLine());
                        Console.WriteLine($"Количество вхождений {ch} в строке равно {str.CountLetter(ch)}");
                        Console.WriteLine("\n-----------\nНажмите ESC для прекращения действия");
                    } while (Console.ReadKey().Key != ConsoleKey.Escape);
                    

                }
                catch (ArgumentOutOfRangeException)
                { 
                    flag = true;
                    Console.WriteLine("Некорректные входные данные!");
                }
                catch (ArgumentException)
                {
                    flag = true;
                    Console.WriteLine("Некорректные входные данные!");
                }
                catch
                { // ловим любые исключения
                    flag = true;
                    Console.WriteLine("Возникла непредвиведнная ошибка!");
                }


            } while (flag);
        }
    }
}