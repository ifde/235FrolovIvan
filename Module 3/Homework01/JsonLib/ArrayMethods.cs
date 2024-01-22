using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JsonLib
{
    /// <summary>
    /// Contains methods for processing a Customers[] array
    /// </summary>
    public static class ArrayMethods
    {
        /// <summary>
        /// Converts a string into an array. 
        /// Used for "Orders" field.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double[] StringToArray(string value)
        {
            List<double> temp_orders = new List<double>();
            foreach (string temp in value.Replace(" ", "").Split(','))
            {
                temp_orders.Add(double.Parse(temp, new CultureInfo("en")));
            }
            return temp_orders.ToArray();
        }

        /// <summary>
        /// Sorts an array of customers by a given field.
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="field"></param>
        /// <param name="mode">1 - Increasing order. 2 - Decreasing order.</param>
        public static void Sort(Customer[] customers, string field, int mode)
        {
            switch(field)
            {
                case "name":
                    Array.Sort(customers, (a, b) => a.name.CompareTo(b.name) * mode);
                    break;
                case "email":
                    Array.Sort(customers, (a, b) => a.email.CompareTo(b.email) * mode);
                    break;
                case "customer_id":
                    Array.Sort(customers, (a, b) => a.customer_id.CompareTo(b.customer_id) * mode);
                    break;
                case "age":
                    Array.Sort(customers, (a, b) => a.age.CompareTo(b.age) * mode);
                    break;
                case "city":
                    Array.Sort(customers, (a, b) => a.city.CompareTo(b.city) * mode);
                    break;
                default:
                    throw new ArgumentException("Такого поля не существует. Сортировка невозможна");

            }
        }

        /// <summary>
        /// Filters an array of customers by a given field and its value
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Customer[] Filter(Customer[] customers, string field, string value)
        {
            List<Customer> res = new List<Customer>(); // method output 

            foreach(Customer customer in customers)
            {
                switch(field)
                {
                    case "name":
                        if (customer.name == value) res.Add(customer);
                        break;
                    case "email":
                        if (customer.email == value) res.Add(customer);
                        break;
                    case "customer_id":
                        if (customer.customer_id == int.Parse(value)) res.Add(customer);
                        break;
                    case "age":
                        if (customer.age == int.Parse(value)) res.Add(customer);
                        break;
                    case "city":
                        if (customer.city == value) res.Add(customer);
                        break;
                    case "is_premium":
                        if (customer.is_premium == (value == "true" ? true : false)) res.Add(customer);
                        break;
                    case "orders":
                        // checking if the orders match
                        if (customer.orders.Length != StringToArray(value).Length) break;
                        bool flag = true;
                        for (int i = 0; i < value.Length; i++)
                        {
                            if (customer.orders[i] != StringToArray(value)[i]) flag = false; break;
                        }
                        if (flag) res.Add(customer);
                        break;
                    default:
                        throw new ArgumentException("Такого поля не существует. Фильтрация невозможна");
                }
            }

            return res.ToArray();
        }
    }
}
