/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      Self 02.
   Дата:      16.09.2023
*/

namespace Self02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month;
            month = Console.ReadLine();

            switch (month)
            {
                case "January" or "Январь":
                    Console.WriteLine(1);
                    break;
                // and so on..
                default: 
                    Console.WriteLine("Такого месяца на существует");
                    break;
            }

        }
    }
}