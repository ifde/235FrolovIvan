/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self03
  Дата:      07.10.2023
*/

//Напишите метод для нахождения максимального
//элемента в одномерном массиве. Метод должен возвращать
//значение false, если переданный массив пуст или равен или
//true при удачном нахождении максимума.
//Сам максимальный элемент должен сохраняться в виде out-
//параметра, при возврате false ему присваивается 0
//В основной программе организуйте ввод одномерного количества
//– первым указывается количество элементов, а затем сами
//элементы. После этого найдите максимальный элемент с
//помощью реализованного метода.
//Обеспечьте проверку некорректных данных (в том числе на
//отрицательный размер массива).

using System;

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

                int n; // длина массива
                int[] a; // массив целых чисел длины n
                Console.WriteLine("Введите размер массива:");
                // вводим длину массива A
                while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Введите размер массива:");
                }
                a = new int[n];

                Console.WriteLine($"Введите последовательно {n} элементов массива:");
                for (int i = 0; i < n; i++)
                {
                    int temp; // очередной элемент массива
                    while (!int.TryParse(Console.ReadLine(), out temp))
                    {
                        Console.WriteLine("Wrong input. Try again.");
                    }
                    a[i] = temp;
                }
                int maxValue; // масимальный элемент массива
                if (TryFindMaxElement(a, out maxValue)) Console.WriteLine($"Масксимальный элемент массива равен {maxValue}");
                else Console.WriteLine($"Массив пустой");

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public static bool TryFindMaxElement(int[] array, out int maxValue)
        {
            maxValue = 0;
            if (array.Length == 0) return false;
            maxValue = array[0];
            foreach (int elem in array)
            {
                if (maxValue < elem) maxValue = elem;
            }
            return true;
        }
    }
}