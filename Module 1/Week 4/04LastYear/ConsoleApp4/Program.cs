/*
 Дисциплина: "Программирование"
 Группа:      БПИ235(2)
 Студент:     Фролов Иван Григорьевич
 Задача:      4
   Дата:      23.09.2023
*/

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint a;
            do
            {
                Console.Write("Введите a: ");
            } while (!uint.TryParse(Console.ReadLine(), out a));

            Sums(a, out uint sumEven, out uint sumOdd);

            Console.WriteLine($"Сумма четных = {sumEven}\nСумма нечетных = {sumOdd}");
        }

        static void Sums(uint number, out uint sumEven, out uint sumOdd)
        {
            sumEven = 0;
            sumOdd = 0;
            while (number != 0)
            {
                sumEven += number % 10;
                number /= 10;
                sumOdd += number % 10;
                number /= 10;
            }
            
        }

    }
}