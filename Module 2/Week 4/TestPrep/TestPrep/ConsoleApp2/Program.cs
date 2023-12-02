/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Вариант:     XXX 
Дата:        2.12.2023
*/


using Drinks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // repeat program
            do
            {
                Console.Clear();

                Drink[] drinks;
                List<Drink> temp = new List<Drink>(); // temporary list for drinks[]
                do
                {
                    int type; // type of a drink
                              // inputting type
                    Console.WriteLine("Введите тип напитка.\n1 = Tea.\n2 = Vine.\n3 = Beer.");
                    while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 3)
                    {
                        Console.WriteLine("Введено неверное значение. Повторите попытку.");
                    }
                    // inputting name
                    Console.WriteLine("Введите название.");
                    string name = Console.ReadLine() + "";

                    // inputting price
                    Console.WriteLine("Введите цену.");
                    double price;
                    while (!double.TryParse(Console.ReadLine(), out price) || price <= 0)
                    {
                        Console.WriteLine("Введено неверное значение. Повторите попытку.");
                    }

                    temp.Add(type switch
                    {
                        1 => new Tea(name, price),
                        2 => new Vine(name, price),
                        _ => new Beer(name, price)
                    });

                    Console.WriteLine("-------------\nНажмите Y для завершения ввода. Нажмите любую другую клавишу для продолжения.\n-------------");
                } while (Console.ReadKey().Key != ConsoleKey.Y);
                Console.Write("\b"); // deteleting "Y" from the command line


                drinks = temp.ToArray();

                // outputting info
                Console.WriteLine("Информация о напитках:");
                foreach (Drink drink in drinks)
                {
                    Console.WriteLine(drink);
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}