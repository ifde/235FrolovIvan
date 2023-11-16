namespace AbstractTestLibrary
{
    // Абстрактный класс UnitBase.
    // Определяет набор полей для классов наследников:
    abstract public class UnitBase
    {
        protected int unit_code; // номер единицы
        protected double price; // цена за единицу
        protected string name; // название

        public int Unit_code
        {
            get => unit_code;
            set => unit_code = value;
        }

        public double Price
        {
            get => price;
            set => price = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// Calculates the discounted price
        /// </summary>
        /// <param name="discount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        virtual public double Discount(int discount)
        {
            if (discount <= 0 || discount > 100) { throw new ArgumentException("Значение скидки указано неверно"); }
            return price * (1 - (double)discount / 100);
        }
    }

    // Book - класс определяет книгу. 
    // Наследует  абстрактный класс UnitBase
    public class Book : UnitBase
    {
        private int no_of_pages; // количество страниц в книге
        private bool _isBestSeller; // является ли бестселлером

        public Book(int no_of_pages, bool isBestSeller)
        {
            this.no_of_pages = no_of_pages;
            _isBestSeller = isBestSeller;
        }
    }

    // Card - класс определяет карточки.
    // Наследует абстрактный класс UnitBase
    public class Card : UnitBase
    {
        private string message; // сообщение

        public Card(string message)
        {
            this.message = message;
        }
    }

    // CD - класс определяет лазерный диск. 
    // Наследует абстрактный класс UnitBase
    public class CD : UnitBase
    {
        private int playing_time; // время звучания диска

        public CD(int playing_time)
        {
            this.playing_time = playing_time;
        }
    }



}