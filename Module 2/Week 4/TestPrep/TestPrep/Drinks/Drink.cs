namespace Drinks
{
    abstract public class Drink
    {
        protected string name; 
        protected double price;

        protected Random random = new Random(); // randomizer

        abstract public double Price { get; }

        public Drink(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
    }
}