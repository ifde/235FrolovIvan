/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      5
 Дата:       16.11.2023
*/

using AbstractTestLibrary;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            UnitBase[] arr = new UnitBase[30];

            for (int i = 0; i < arr.Length; i++)
            {
                int object_number = rand.Next(3); // defines which object to create

                if (object_number == 0) arr[i] = new Book(rand.Next(1, 101),
                    rand.Next(2) == 0 ? false : true);

                else if (object_number == 1) arr[i] = new Card($"Message {rand.Next(10)}");

                else arr[i] = new CD(rand.Next(1, 150));

                arr[i].Unit_code = i;
                arr[i].Name = new string((char)('a' + rand.Next('z' - 'a' + 1)), rand.Next(1, 11));
                arr[i].Price = rand.Next(100, 1001);
            }

            int discount;
            Console.WriteLine("Введите значение скидки в процентах:");
            while (!int.TryParse(Console.ReadLine(), out discount) || discount <= 0 || discount > 100)
            {
                Console.WriteLine("Неверный ввод. Повторите попытку.");
            }
            Console.WriteLine(Environment.NewLine);

            foreach (UnitBase elem in arr)
            {
                Console.WriteLine($"Item {elem.Name}: Full price = {elem.Price}, Discounted price = {elem.Discount(discount)}");
            }
        }
    }
}