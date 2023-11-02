/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1
Класс MyComplex, представляет комплексное число:
re, im – вещественные поля класса, представляющие мнимую и действительную части;
Конструктор с двумя вещественными параметрами используется для присваивания значений полям;
Метод Mod() возвращает модуль комплексного числа;
Операции --, true и false перегружены для объектов класса. 
-- уменьшает значение вещественной и мнимой части на единицу, 
true возвращается для объектов, модуль которых больше 1, 
false - в противном случае.


 Дата:       2.11.2023
*/

using System.Data.Common;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ConsoleApp8
{
    internal class MyComplex
    {
        double re, im; // real and imaginery parts respectively

        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="re"></param>
        /// <param name="im"></param>
        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        /// <summary>
        /// Find a module of a complex number
        /// </summary>
        /// <returns></returns>
        public double Mod()
        {
            return Math.Sqrt(re * re + im * im);
        }

        public static MyComplex operator --(MyComplex number)
        {
            return new MyComplex(number.im - 1, number.re - 1); // he've got to return a new obect in order
                                                                // for the method to perform correctly.
                                                                // It always performs the operation first and
                                                                // then decided what to return.

        }

        public static bool operator true(MyComplex number)
        {
            return number.Mod() > 1;
        }

        public static bool operator false(MyComplex number)
        {
            return number.Mod() <= 1;
        }

        public override string ToString()
        {
            return $"{re:f2} + {im:f2}i";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyComplex c1 = new MyComplex(4, 3.3);
            Console.WriteLine($"Модуль исходного комплексного числа = {c1.Mod():f2}");
            while (c1)
            {
                Console.WriteLine($"c1 => {c1}");
                c1--;
            }
            Console.WriteLine($"Модуль полученного числа = {c1.Mod():f2}");
            //string.Format("{0}{1}{2}", 1, 2, 3);

        }
    }
}