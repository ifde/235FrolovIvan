/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      Self02
   Дата:      24.09.2023
*/


namespace Self02
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            uint all = 0, // 
                int_num = 0, // integers 
                double_num = 0; // doubles 
            string temp; // user's input
            int a; // to catch integers in TryParse
            double b; // to catch doubles in TryParse
            Console.WriteLine($"Input your numbers below:");
            do
            {
                temp = Console.ReadLine();
                // is input is 0?
                if (temp == "0")
                {
                    continue;
                }
                // is integer?
                if (int.TryParse(temp, out a))
                {
                    int_num++;
                }
                // is double? 
                else if (double.TryParse(temp, out b))
                {
                    double_num++;
                }
                // all the rest
                else
                {
                    all++;
                }

            } while (temp != "0");

            Console.WriteLine($"The number of integers is {int_num}");
            Console.WriteLine($"The number of doubles is {double_num}");
            Console.WriteLine($"The number of other numbers is {all}");
        }
    }
}