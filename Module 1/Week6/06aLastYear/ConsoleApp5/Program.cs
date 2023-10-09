/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      5
Написать метод ConvertHex2Bin(), выполняющий перевод шестнадцатеричного числа в двоичное
 Дата:      09.10.2023
*/

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Шестнадцатеричное число: 5A1");
            Console.WriteLine($"В бинарном формате: {ConvertHex2Bin("5A1")}");
        }

        /// <summary>
        /// Перевод шестнадцатеричного числа в двоичное
        /// </summary>
        /// <param name="HexNumber"></param>
        /// <returns></returns>
        static string ConvertHex2Bin(string HexNumber)
        {
            int value = Convert.ToInt32(HexNumber, 16);
            return Convert.ToString(value, 2);
        }

    }
}