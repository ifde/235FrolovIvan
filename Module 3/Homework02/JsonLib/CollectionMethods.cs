using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonLib
{
    /// <summary>
    /// Neccessary methods used to work with the list of books
    /// </summary>
    public static class CollectionMethods
    {
        /// <summary>
        /// Sorts books by a field given the specific mode
        /// </summary>
        /// <param name="books"></param>
        /// <param name="field"></param>
        /// <param name="mode"></param>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Applies SubscribeBorrowers() to each book
        /// </summary>
        /// <param name="books"></param>
        public static void SubscribeBorrowersForAllBooks(this List<Book> books)
        {
            foreach (Book book in books)
            {
                book.SubscribeBorrowers();
            }
        }

        /// <summary>
        /// Find a book by a given id
        /// </summary>
        /// <param name="books"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Book FindBookById(List<Book> books, string bookId)
        {
            Book? book = books.Find(b => b.BookId == bookId);
            if (book == null) throw new ArgumentException("Такой книги не существует.");
            return book;
        }

        /// <summary>
        /// Edits a field in the book
        /// </summary>
        /// <param name="book"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void EditBook(Book book)
        {

            Console.WriteLine(book.ToJSON());

            string field = GetField("title", "author", "publicationYear", "genre", "isAvailable", "borrowers"); // given field

            string value;

            if (field == "publicationYear")
            {
                value = GetYear();
                book.ChangeField(field, value);
            }
            else if (field == "borrowers")
            {
                int number = GetBorrowerNumber(book);
                string borrowerField = GetField("borrowerName", "borrowDate", "dueDate");

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
            else if (field == "isAvailable")
            {
                book.OnAccessibilityChanged();
            }
            else
            {
                Console.WriteLine("Введите новое значение поля:");
                value = Console.ReadLine() + "";
                book.ChangeField(field, value);
            }
        }

        /// <summary>
        /// Gets a number of the borrower from the user
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static int GetBorrowerNumber(Book book)
        {
            int number;
            Console.WriteLine("Введите порядковый номер читателя (с нуля)");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number) && number >= 0 && number < book.Borrowers.Count) break;
                Console.WriteLine("Wrong input. Try again.");
            }
            return number;
        }

        /// <summary>
        /// Gets a field from the user
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static string GetField(params string[] fields)
        {
            Console.WriteLine($"Введите поле для изменения.\nВарианты: {string.Join(", ", fields)}");
            string input;
            while (true)
            {
                input = Console.ReadLine() + "";
                if (fields.Contains(input)) break;
                Console.WriteLine("Wrong input. Try again.");
            }
            return input;
        }

        /// <summary>
        /// Gets a date in the correct format from the user
        /// </summary>
        /// <returns></returns>
        public static string GetDate()
        {
            DateTime dt;
            string value;
            Console.WriteLine("Введите дату в корректном формате (yyyy-MM-dd):");
            while (true)
            {
                try
                {
                    value = Console.ReadLine() + "";
                    dt = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.CurrentCulture);
                    break;
                }
                catch
                {
                    Console.WriteLine("Wrong input. Try again.");
                }
            }
            return value;
        }

        /// <summary>
        /// Gets a year in the correct format from the user
        /// </summary>
        /// <returns></returns>
        public static string GetYear()
        {
            int value;
            Console.WriteLine("Введите нужный год:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out value) && value > 0 && value < 2024) break;
                Console.WriteLine("Wrong input. Try again.");
            }

            return value.ToString();
        }

        /// <summary>
        /// Gets a book by its id
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public static Book GetBookById(List<Book> books)
        {
            Console.WriteLine("Введите ID книги для редактирования:");
            string bookId; // given id
            Book book;
            while (true)
            {
                try
                {
                    bookId = Console.ReadLine() + "";
                    book = FindBookById(books, bookId);
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Wrong input.");
                }
            }
            return book;
        }

        /// <summary>
        /// Gets a mode from the user
        /// </summary>
        /// <returns></returns>
        public static int GetMode()
        {
            Console.WriteLine("1 - по возрастанию. (-1) - по убыванию");
            int mode;
            // input mode
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out mode) && (mode == 1 || mode == -1)) break;
                Console.WriteLine("Такой команды не существует. Повторите попытку.");
            }
            return mode;
        }

        /// <summary>
        /// Gets a command from the user
        /// </summary>
        /// <returns></returns>
        public static int GetCommandMenu1()
        {
            int command;
            Console.WriteLine("\n---------\nМеню:\n" +
                       "1. Отсортировать данные по одному из полей.\n" +
                       "2. Изменить данные.\n" +
                       "3. Выйти из программы\n---------\n\n" +
                       "Укажите номер пункта меню для запуска действия:");

            // input command
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out command) && command >= 1 && command <= 3) break;
                Console.WriteLine("Такой команды не существует. Повторите попытку.");
            }
            return command;
        }
        /// <summary>
        /// Gets a list a books from the file
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<Book> GetBooks()
        {
            Console.WriteLine("Введите имя JSON-файла в папке, где лежит Program.cs (без указания расширения):");
            string path = $@"{Console.ReadLine()}.json";
            List<Book>? books = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(path), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (books == null) throw new ArgumentException("Файл не был корректно прочитан.");
            return books;
        }
    }
}
