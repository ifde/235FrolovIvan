﻿/*
  Дисциплина: "Программирование"
  Группа:      БПИ235(2)
  Студент:     Фролов Иван Григорьевич
  Задача:      Задача 2. Написать метод для вычисления площади и длины окружности, радиус которой задает вещественный параметр. 
                В основной программе, вводя значения радиуса, с помощью обращения к методу, вычислять площадь и длину окружности. 
                При вводе применять метод double.TryParse() и проверять корректность введенного значения. 
                При выводе использовать форматную строку метода WriteLine(). 
                Окончание работы программы – ввод нулевого или отрицательного значения радиуса.
    Дата:      15.09.2023
*/


namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double r;
            do
            {
                Console.WriteLine("Введите вещественное число: ");
            } while (!double.TryParse(Console.ReadLine(), out r));
            Console.WriteLine($"Ответ: площадь равна {S(r):f3}, периметр равен {P(r):f3}");
        }

        static double P (double r)
        {
            return 2 * Math.PI * r;
        }
        static double S(double r)
        {
            return Math.PI * Math.Pow(r, 2);
        }
    }
}