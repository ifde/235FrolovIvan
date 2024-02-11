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
    public class Borrower
    {
        [JsonInclude]
        public string BorrowerId { get; private set; }
        [JsonInclude]
        public string BorrowerName { get; private set; }
        [JsonInclude]
        public DateTime BorrowDate { get; private set; }
        [JsonInclude]
        public DateTime DueDate { get; private set; }

        public Borrower(string borrowerId, string borrowerName, DateTime borrowDate, DateTime dueDate)
        {
            BorrowerId = borrowerId;
            BorrowerName = borrowerName;
            BorrowDate = borrowDate;
            DueDate = dueDate;
        }

        public Borrower() { }

        public void ChangeField(string fieldName, string value)
        {
            switch (fieldName)
            {
                case "borrowerName": BorrowerName = value; break;
                case "borrowDate": BorrowDate = DateTime.ParseExact(value, "yyyy-MM-dd,fff", CultureInfo.CurrentCulture); break;
                case "dueDate": DueDate = DateTime.ParseExact(value, "yyyy-MM-dd,fff", CultureInfo.CurrentCulture); break;
                default: throw new ArgumentException("Такого поля не предусмотрено");
            }
        }

        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }

        public void OnAccessibilityChangedEventHandler(object sender, ChangeArgs e)
        {
            Book book = (Book)sender;
            Console.WriteLine($"Теперь книгу {book.Title} можно забрать!");
        }
    }
}
