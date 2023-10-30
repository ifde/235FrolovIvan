/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:     XXX
 Дата:       30.10.2023
*/

using System;

namespace ConsoleApp1
{

    internal class Birthday
    {
        string name; // person's name
        int year, month, day; // person's birthday

        public Birthday (string name, int year, int month, int day)
        {
            this.name = name;
            this.year = year;
            this.month = month;
            this.day = day;
        }

        DateTime Date // date of birthday
        {
            get { return new DateTime(year, month, day); }
        }

        public int daysBeforeBirthday
        {
            get
            {
                int nowDays = DateTime.Now.DayOfYear; // число дней от начала года
                int myDays = Date.DayOfYear; // номер дня рождения от начала года
                return myDays > nowDays ? myDays - nowDays : 365 + myDays - nowDays;
            }
        }

        public string Info ()
        {
            return $"Имя {name} родился {day} : {month} : {year}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Birthday mark = new Birthday("Mark", 2000, 1, 1);
            Console.WriteLine(mark.Info());
            Console.WriteLine(mark.daysBeforeBirthday);

        }
    }
}