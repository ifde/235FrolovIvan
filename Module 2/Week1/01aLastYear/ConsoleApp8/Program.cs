/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      6
Разработать класс Schedule, в котором неделя представлена при помощи
индексатора со строковым индексом – днём недели.
Протестировать класс в консольном приложении

 Дата:       1.11.2023
*/

using System.Globalization;
using System.Runtime.CompilerServices;

namespace ConsoleApp8
{
    internal class Schedule
    {
        string[] days = new string[7]; // an array of days

        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="days"></param>
        public Schedule(params string[] days)
        {
            for (int i = 0; i < days.Length; i++)
            {
                this.days[i] = days[i];
            }
        }

        /// <summary>
        /// An array Schedule[] property
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public string this[string day]
        {
            get
            {
                return day switch
                {
                    "понедельник" => days[0] == null ? "No lectures" : days[0],
                    "вторник" => days[1] == null ? "No lectures" : days[1],
                    "среда" => days[2] == null ? "No lectures" : days[2],
                    "четверг" => days[3] == null ? "No lectures" : days[3],
                    "пятница" => days[4] == null ? "No lectures" : days[4],
                    "суббота" => days[5] == null ? "No lectures" : days[05],
                    "воскресенье" => days[6] == null ? "No lectures" : days[6],
                    _ => "" 
                };
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Schedule Module_2 = new Schedule("9_00", "10_30",
                         null, "15_00", "13_40");
            Console.WriteLine("График начала занятий в модуле 2:");
            Console.WriteLine("понедельник: \t" + Module_2["понедельник"]);
            Console.WriteLine("вторник: \t" + Module_2["вторник"]);
            Console.WriteLine("среда:    \t" + Module_2["среда"]);
            Console.WriteLine("четверг: \t" + Module_2["четверг"]);
            Console.WriteLine("пятница: \t" + Module_2["пятница"]);
            Console.WriteLine("суббота: \t" + Module_2["суббота"]);
            Console.WriteLine("воскресенье: \t" + Module_2["воскресенье"]);

        }
    }
}