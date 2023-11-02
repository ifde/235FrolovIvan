/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      2
Используя код класса Fraction, разработайте приложение – калькулятор дробей. 
Дополните класс перегруженными операциями ++ и --, 
позволяющими добавлять к дроби единицу и вычитать из дроби единицу. 
Калькулятор должен позволять выполнять основные арифметические операции над дробями, 
а также преобразовывать простые дроби в десятичные и наоборот.



 Дата:       2.11.2023
*/

using System.Data.Common;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace ConsoleApp2
{

    public class Fraction
    {
        int num; // числитель
        int den; // знаменатель
        public Fraction(int n, int d)
        { // Конструктор
            if (d > 0) { num = n; den = d; return; }
            if (d < 0) { num = -n; den = -d; return; }
            throw new ArgumentException($"Нулевой знаменатель: {n}/{d}", "d");
        }
        public void Print() => Console.WriteLine(this.ToString());

        public override string ToString()
        {
            return $"{num}/{den}";
        }

        // Унарный минус.
        static public Fraction operator -(Fraction f)
        {
            return new Fraction(-f.num, f.den);
        }

        // Бинарный плюс.
        static public Fraction operator +(Fraction f1, Fraction f2)
        {
            int n = f1.num * f2.den + f1.den * f2.num;
            int d = f1.den * f2.den;
            return new Fraction(n, d);
        }

        // Бинарный минус.
        static public Fraction operator -(Fraction f1, Fraction f2)
        {
            int n = f1.num * f2.den - f1.den * f2.num;
            int d = f1.den * f2.den;
            return new Fraction(n, d);
        }


        static public bool operator <(Fraction f1, Fraction f2)
        {
            return f1.num * f2.den < f1.den * f2.num;
        }
        static public bool operator >(Fraction f1, Fraction f2)
        {
            return f2 < f1;
        }

        public static implicit operator Fraction(int x) => new Fraction(x, 1);

        public static implicit operator double(Fraction f) => (double)f.num / f.den;

        public static implicit operator Fraction(double x)
        {
            string str = x.ToString();
            int power = str.Length - str.IndexOf(',');
            return new Fraction((int)(x * Math.Pow(10, power)), (int)Math.Pow(10, power));
        }

        public static explicit operator int(Fraction f) => f.num / f.den;
        static public bool operator true(Fraction f) => f.num > f.den;
        static public bool operator false(Fraction f) => f.num <= f.den;

        public static implicit operator bool(Fraction f) => f.num > f.den;

        // Работает по короткой схеме для &&.
        public static Fraction operator &(Fraction lhs, Fraction rhs)
        => new Fraction(lhs.num, lhs.den);

        // Работает по короткой схеме для ||.
        public static Fraction operator |(Fraction lhs, Fraction rhs)
        => new Fraction(rhs.num, rhs.den);

        public static Fraction operator ++(Fraction f)
        {
            return new Fraction(f.num + f.den, f.den);
        }

        public static Fraction operator --(Fraction f)
        {
            return new Fraction(f.num - f.den, f.den);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction a = 13.2;
            Fraction b = -1.10;
            a.Print();
            b.Print();
        }
    }
}