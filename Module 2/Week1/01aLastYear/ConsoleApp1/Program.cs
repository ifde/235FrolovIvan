/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1
 Дата:       30.10.2023
*/

using System;

namespace ConsoleApp1
{

    internal class Birthday
    {
        string name; // person's name
        int year, month, day; // person's birthday

        public Birthday(string name, int year, int month, int day)
        {
            this.name = name;
            this.year = year;
            this.month = month;
            this.day = day;
        }

        public Birthday()
        {
            this.year = 1970;
            this.month = 1;
            this.day = 1;
        }

        DateTime Date // date of birthday
        {
            get { return new DateTime(year, month, day); }
        }

        public int daysBeforeBirthday // number of days before birthday
        {
            get
            {
                int nowDays = DateTime.Now.DayOfYear; // число дней от начала года
                int myDays = Date.DayOfYear; // номер дня рождения от начала года
                return myDays > nowDays ? myDays - nowDays : 365 + myDays - nowDays;
            }
        }

        public string Info() // infor about a person
        {
            return $"Имя {name} родился {day} : {month} : {year}";
        }

        public string GetBirthday(string format) // print birthay in a given format
        {
            return Date.ToString(format);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Birthday mark = new Birthday("Mark", 2000, 1, 1);
            Console.WriteLine(mark.Info());
            Console.WriteLine(mark.GetBirthday("dd MM yyyy"));
            Console.WriteLine(mark.GetBirthday("dd-MM-yy"));
            Console.WriteLine(mark.daysBeforeBirthday);

        }
    }
}