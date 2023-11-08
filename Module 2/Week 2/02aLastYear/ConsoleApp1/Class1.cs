using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// A class that represents an item.
    /// </summary>
    internal class Item
    {
        string name;
        double price;
        int quantity;

        /// <summary>
        /// Item's name
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Item's price
        /// </summary>
        public double Price
        {
            get { return price; }
        }

        /// <summary>
        /// Quantity of Items
        /// </summary>
        public int Quantity
        {
            get { return quantity; }
        }

        /// <summary>
        /// A constuctor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        public Item(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return $"Item \"{name}\": price = {price}, quantity = {quantity}"; 
        }
    }

    /// <summary>
    /// A class that represents a shopping cart.
    /// </summary>
    internal class ShoppingCart
    {
        private int _itemCount; // количество предметов в корзине
        private double _totalPrice; // цена всех предметов в корзине
        private int _capacity; // текущая вместимость корзины
        private Item[] _cart;

        /// <summary>
        /// A property for getting _totalPrice
        /// </summary>
        public double TotalPrice
        {
            get { return _totalPrice; }
        }

        /// <summary>
        /// Создаёт новый экземпляр корзины с вместимостью в 5 элементов
        /// </summary>
        public ShoppingCart()
        {
            _capacity = 5;
            _itemCount = 0;
            _totalPrice = 0.0;
            _cart = new Item[_capacity];
        }

        /// <summary>
        /// Добавляет предмет в корзину
        /// </summary>
        /// <param name="itemName">Название предмета</param>
        /// <param name="price">Цена предмета</param>
        /// <param name="quantity">Количество предметов</param>
        public void AddToCart(string itemName, double price, int quantity)
        {
            Item item = new Item(itemName, price, quantity);
            if (_itemCount >= _capacity) throw new Exception("Коризна переполнена.");
            _cart[_itemCount++] = item;
            _totalPrice += price * quantity;
        }

        /// <summary>
        /// Увеличивает вместимость корзины на 3
        /// </summary>
        private void IncreaseSize()
        {
            _capacity += 3;
            Array.Resize(ref _cart, _capacity);
        }

        /// <summary>
        /// Возвращает предметы в корзине с дополнительной информацией
        /// </summary>
        public override string ToString()
        {
            string contents = "\nShopping Cart\n";

            contents += "\nItem\t\tUnit Price\tQuantity\tTotal\n";

            for (int i = 0; i < _itemCount; i++)
                contents += _cart[i] + "\n";

            contents += $"\nTotal Price: {_totalPrice:C}\n";

            return contents;
        }


    }
}
