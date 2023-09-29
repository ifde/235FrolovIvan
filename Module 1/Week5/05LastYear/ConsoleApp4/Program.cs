/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      4
  Дата:      28.09.2023
*/

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static uint[] Reccur(uint a0)
        {
            uint[] arr = new uint[0]; // итоговый массив
            uint a1 = a0; // вычисление следующего элемента
            do
            {
                Array.Resize(ref arr, arr.Length + 1);
                arr[^1] = a1;
                a0 = a1;
                a1 = a0 % 2 == 0 ? a0 / 2 : (3 * a0 + 1);
            } while (a1 != 1);

            return arr;
        }

        static void PrintReccur(ref uint[] arr)
        {
            for (uint i = 0; i < arr.Length; i++)
            {
                Console.Write($"");
            }
        }
    }
}