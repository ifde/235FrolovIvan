using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonLib
{
    public class Borrower
    {
        public string BorrowerId { get; private set; }
        public string BorrowerName { get; private set; }
        public DateTime BorrowDate { get; private set; }
        public DateTime DueDate { get; private set; }

        public Borrower(string borrowerId, string borrowerName, DateTime borrowDate, DateTime dueDate)
        {
            BorrowerId = borrowerId;
            BorrowerName = borrowerName;
            BorrowDate = borrowDate;
            DueDate = dueDate;
        }

        public Borrower() { }

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
