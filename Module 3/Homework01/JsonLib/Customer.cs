using System.Globalization;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace JsonLib
{
    public class Customer
    {
        public readonly int customer_id;
        public readonly string name;
        public readonly string email;
        public readonly int age;
        public readonly string city;
        public readonly bool is_premium;
        public readonly double[] orders;

        public Customer(Match values)
        {
            customer_id = int.Parse(values.Groups["customer_id"].Value);
            name = values.Groups["name"].Value[1..^1];
            email = values.Groups["email"].Value[1..^1];
            age = int.Parse(values.Groups["age"].Value);
            city = values.Groups["city"].Value[1..^1];
            is_premium = values.Groups["is_premium"].Value == "true" ? true : false;

            List<double> temp_orders = new List<double>();
            foreach (string temp in values.Groups["orders"].Value[1..^1].Replace(" ", "").Split(','))
            {
                temp_orders.Add(double.Parse(temp, new CultureInfo("en")));
            }
            orders = temp_orders.ToArray();
        }

        public Customer()
        {
            customer_id = default;
            name = "";
            email = "";
            age = default;
            city = "";
            is_premium = default;
            orders = new double[0];
        }
    }
}