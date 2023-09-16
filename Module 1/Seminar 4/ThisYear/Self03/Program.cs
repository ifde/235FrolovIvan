/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      Self 03.
   Дата:      16.09.2023
*/

namespace Self03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Введите код операции: ");
                int.TryParse(Console.ReadLine(), out n);
            } while (!(n == 1 | n == 2 | n == 3 | n == 4));

            
        }
    }
}