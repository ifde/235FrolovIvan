using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonLib
{
    /// <summary>
    /// Represents a book from the JSON file
    /// </summary>
    public class Book
    {
        public event EventHandler<EventArgs> AccessibilityChanged;
        public event EventHandler<ChangeArgs> Updated;

        [JsonInclude]
        public string BookId { get; private set; }
        [JsonInclude]
        public string Title { get; private set; }
        [JsonInclude]
        public string Author { get; private set; }
        [JsonInclude]
        public int PublicationYear { get; private set; }
        [JsonInclude]
        public string Genre { get; private set; }
        [JsonInclude]
        public bool IsAvailable { get; private set; }
        [JsonInclude]
        public List<Borrower> Borrowers { get; private set; }

        public Book(string bookId, string title, string author, int publicationYear, string genre, bool isAvailable, List<Borrower> borrowers)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Genre = genre;
            IsAvailable = isAvailable;
            Borrowers = borrowers;
        }

        /// <summary>
        /// Subscribes borrowes of a book to "AccessibilityChanged" event.
        /// </summary>
        public void SubscribeBorrowers()
        {
            foreach (Borrower borrower in Borrowers) AccessibilityChanged += borrower.OnAccessibilityChangedEventHandler;
        }

        /// <summary>
        /// Changes the value of the given field
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public void ChangeField(string fieldName, string value)
        {
            switch (fieldName)
            {
                case "title": Title = value; break;
                case "author": Author = value; break;
                case "publicationYear": PublicationYear = int.Parse(value); break;
                case "genre": Genre = value; break;
                default: throw new ArgumentException("Такого поля не предусмотрено");
            }
            OnUpdated(DateTime.Now);
        }

        /// <summary>
        /// Changes the value of the given field of the borrower
        /// </summary>
        /// <param name="number"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        public void ChangeBorrowerField(int number, string field, string value)
        {
            Borrower borrower = Borrowers[number];
            borrower.ChangeField(field, value);
            OnUpdated(DateTime.Now);
        }

        public Book() { }

        /// <summary>
        /// Convers book to JSON format
        /// </summary>
        /// <returns></returns>
        public string ToJSON()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }

        /// <summary>
        /// Invokes "Updated" event
        /// </summary>
        /// <param name="dt"></param>
        public void OnUpdated(DateTime dt)
        {
            Updated?.Invoke(this, new ChangeArgs(dt));
        }

        /// <summary>
        /// Invokes "AccessibilityChanged" event
        /// </summary>
        public void OnAccessibilityChanged()
        {
            IsAvailable = !IsAvailable;

            // If a book became unavailable, we do nothing
            if (!IsAvailable)
            {
                OnUpdated(DateTime.Now);
                return;
            }
            
            AccessibilityChanged?.Invoke(this, new EventArgs());

            // Randomly selecting a borrower who receives a book.
            Random rnd = new Random();
            Borrower borrower = Borrowers.ElementAt(rnd.Next(Borrowers.Count)); // randomly selected borrower
            borrower.ReceiveBook(this);
            Borrowers.Remove(borrower); // removing the borrower who received the book
            IsAvailable = !IsAvailable; // making a book unavailable

            OnUpdated(DateTime.Now);
        }
    }
}