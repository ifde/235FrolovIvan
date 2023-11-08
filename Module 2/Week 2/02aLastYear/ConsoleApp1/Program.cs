/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      1
Дата:        08.11.23
*/

using System;
using System.Xml;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // повтор решения 
            do
            {
                Console.Clear();

                ShoppingCart cart = new ShoppingCart(); // a shopping cart

                Console.WriteLine("Добро пожаловать в магазин!\n");
                // цикл совершения покупок
                while (true)
                {
                    string name; // item's name
                    double price; // item's price
                    int quantity; // item's quantity

                    // input name
                    Console.WriteLine("Введите имя товара:");
                    name = Console.ReadLine() + "";

                    // input price
                    Console.WriteLine("Введите цену товара:");
                    while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
                    {
                        Console.WriteLine("Цена введена некорректно. Повторите попытку.");
                    }

                    // input quantity
                    Console.WriteLine("Введите количество товаров данного типа:");
                    while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                    {
                        Console.WriteLine("Количество введено некорректно. Повторите попытку.");
                    }

                    try
                    {
                        cart.AddToCart(name, price, quantity);
                        Console.WriteLine(cart);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                    

                    Console.WriteLine("Нажмите ENTER, чтобы завершить покупки.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }

                Console.WriteLine($"Пожалуйста, заплатите {cart.TotalPrice:C}");

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}