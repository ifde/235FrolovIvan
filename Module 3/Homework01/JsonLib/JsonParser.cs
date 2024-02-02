using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace JsonLib
{
    /// <summary>
    /// Methods for managing a JSON-file
    /// </summary>
    public static class JsonParser
    {
        /// <summary>
        /// Writes data to the Stream
        /// </summary>
        /// <param name="customers"></param>
        public static void WriteJson(Customer[] customers)
        {
            string[] customers_info = new string[customers.Length];
            for (int i = 0; i < customers_info.Length; i++)
            {
                customers_info[i] = "{\n" + $"\t\"customer_id\": {customers[i].customer_id},\n"
                                          + $"\t\"name\": \"{customers[i].name}\",\n"
                                          + $"\t\"email\": \"{customers[i].email}\",\n"
                                          + $"\t\"age\": {customers[i].age},\n"
                                          + $"\t\"city\": \"{customers[i].city}\",\n"
                                          + $"\t\"is_premium\": {(customers[i].is_premium ? "true" : "false")},\n"
                                          + $"\t\"orders\": {ArrayToString(customers[i].orders)}"
                                          + "\n\t}";
            }

            string res = "[\n\t" + string.Join(",\n\t", customers_info) + "\n]";
            Console.Write(res);
        }

        /// <summary>
        /// Converts a double[] array to a string. 
        /// Used in WriteJson() method.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static string ArrayToString(double[] arr)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); // changing the culture to write double numbers with '.'
            string res = "[\n\t";
            for (int i = 0; i < arr.Length - 1; i++)
            {
                res += $"{arr[i]:f2}," + "\n\t";
            }
            res += $"{arr[arr.Length - 1]:f2}" + "\n\t";
            res += "]";
            Thread.CurrentThread.CurrentCulture = culture;
            return res;
        }



        /// <summary>
        /// Reads JSON-file from the Stream and returns an array of customers.
        /// </summary>
        /// <returns></returns>
        public static Customer[] ReadJson()
        {

            string text = ""; // all text from the file

            // Reading lines from the Stream;
            string? line = Console.ReadLine();
            while (line != null)
            {
                text += line;
                line = Console.ReadLine();
            }

            // Each match contains information about the customer
            MatchCollection matches = Regex.Matches(text, @"""customer_id"":\s(?'customer_id'\w+),\s*""name"":\s(?'name'.*?),\s*""email"":\s(?'email'.*?),\s*""age"":\s(?'age'\w+),\s*""city"":\s(?'city'.*?),\s*""is_premium"":\s(?'is_premium'\w+),\s*""orders"":\s(?'orders'\[[^\[]*?\])");
            List<Customer> customers = new List<Customer>();

            // Creating instances of "Customer" objects using given information 
            foreach (Match match in matches)
            {
                customers.Add(new Customer(match));
            }

            return customers.ToArray();
        }
    }
}
