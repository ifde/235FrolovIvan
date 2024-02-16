using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonLib
{
    /// <summary>
    /// Represent a borrower from JSON file. 
    /// In composition with a "Book" class
    /// </summary> 
    public class Borrower
    {
        [JsonInclude]
        public string BorrowerId { get; private set; }
        [JsonInclude]
        public string BorrowerName { get; private set; }
        [JsonInclude]
        public string BorrowDate { get; private set; }
        [JsonInclude]
        public string DueDate { get; private set; }

        public Borrower(string borrowerId, string borrowerName, string borrowDate, string dueDate)
        {
            BorrowerId = borrowerId;
            BorrowerName = borrowerName;
            BorrowDate = borrowDate;
            DueDate = dueDate;
        }

        public Borrower() { }

        /// <summary>
        /// Changes the the value of the given field
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public void ChangeField(string fieldName, string value)
        {
            switch (fieldName)
            {
                case "borrowerName": BorrowerName = value; break;
                case "borrowDate": BorrowDate = value; break;
                case "dueDate": DueDate = value; break;
                default: throw new ArgumentException("Такого поля не предусмотрено");
            }
        }

        /// <summary>
        /// Converts a borrower to JSON format
        /// </summary>
        /// <returns></returns>
        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// Handles an "AccessibilityChanged" event from "Book" class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnAccessibilityChangedEventHandler(object? sender, EventArgs e)
        {
            Book book = (Book)sender;
            Console.WriteLine($"{BorrowerName}, Теперь книгу \"{book.Title}\" можно забрать!");
        }

        /// <summary>
        /// Congratulates a borrower who recieved a book.
        /// </summary>
        public void ReceiveBook(Book book)
        {
            Console.WriteLine($"------\n{BorrowerName}, вы получили книгу \"{book.Title}\"!\n------\n");
        }
    }
}
