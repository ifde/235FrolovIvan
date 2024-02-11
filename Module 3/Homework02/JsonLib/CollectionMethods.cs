using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace JsonLib
{
    public class CollectionMethods
    {
        public static void Sort(List<Book> books, string field, int mode)
        {
            switch (field)
            {
                case "bookId":
                    books.Sort((a, b) => a.BookId.CompareTo(b.BookId) * mode);
                    break;
                case "title":
                    books.Sort((a, b) => a.Title.CompareTo(b.Title) * mode);
                    break;
                case "author":
                    books.Sort((a, b) => a.Author.CompareTo(b.Author) * mode);
                    break;
                case "publicationYear":
                    books.Sort((a, b) => a.PublicationYear.CompareTo(b.PublicationYear) * mode);
                    break;
                case "genre":
                    books.Sort((a, b) => a.Genre.CompareTo(b.Genre) * mode);
                    break;
                default:
                    throw new ArgumentException("Такого поля не существует. Сортировка невозможна");

            }
        }

        public static Book FindBookById(List<Book> books, string bookId)
        {
            Book? book = books.Find(b => b.BookId == bookId);
            if (book == null) throw new ArgumentException("Такой книги не существует.");
            return book;
        }

        public static void EditBook(Book book)
        {

            Console.WriteLine(book.ToJSON());

            Console.WriteLine("Введите поле для изменения.\nВарианты: title, author, publicationYear, genre, borrowers");
            string field = Console.ReadLine() + ""; // given field

            string value;

            if (field == "publicationYear")
            {
                Console.WriteLine("Введите новое значение поля:");
                value = GetYear();
                book.ChangeField(field, value);
            }
            else if (field == "borrowers")
            {
                int number;
                string borrowerField;

                Console.WriteLine("Введите порядковый номер читателя (с нуля)");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out number) && number >= 0 && number < book.Borrowers.Count) break;
                    Console.WriteLine("Wrong input. Try again.");
                }

                Console.WriteLine("Введите поле для изменения.\nВарианты: borrowerName, borrowDate, dueDate");
                borrowerField = Console.ReadLine() + "";

                switch (borrowerField)
                {
                    case "borrowerName":
                        Console.WriteLine("Введите новое значение поля:");
                        book.ChangeBorrowerField(number, "borrowerName", Console.ReadLine() + "");
                        break;
                    case "borrowDate":
                        book.ChangeBorrowerField(number, "borrowDate", GetDate());
                        break;
                    case "dueDate":
                        book.ChangeBorrowerField(number, "dueDate", GetDate());
                        break;
                    default:
                        throw new ArgumentException("Такого поля не существует. Изменение невозможно.");
                }
            }
            else
            {
                Console.WriteLine("Введите новое значение поля:");
                value = Console.ReadLine() + "";
                book.ChangeField(field, value);
            }
        }

        public static string GetDate()
        {
            DateTime dt;
            string value;
            Console.WriteLine("Введите дату в корректном формате:");
            while (true)
            {
                try
                {
                    value = Console.ReadLine() + "";
                    dt = DateTime.ParseExact(value, "yyyy-MM-dd,fff", CultureInfo.CurrentCulture);
                    break;
                }
                catch
                {
                    Console.WriteLine("Wrong input. Try again.");
                }
            }
            return value;
        }

        public static string GetYear()
        {
            int value;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out value) && value > 0 && value < 2024) break;
                Console.WriteLine("Wrong input. Try again.");
            }

            return value.ToString();
        }
    }
}
