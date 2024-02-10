using System.Runtime.CompilerServices;
using System.Text.Json;

namespace JsonLib
{
    public class Book
    {
        public event EventHandler<EventArgs> AccessibilityChanged;
        public event EventHandler<ChangeArgs> Updated;

        public string BookId { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int PublicationYear { get; private set; }
        public string Genre { get; private set; }
        public bool IsAvailable { get; private set; }
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

        public void ChangeField (string fieldName, string value)
        {
            switch (fieldName)
            {
                case "bookId": BookId = value; break;
                case "title": Title = value; break;
                case "author": Author = value; break;
                case "publicationYear": PublicationYear = int.Parse(value); break;
                case "genre": Genre = value; break;
                default: throw new ArgumentException("Такого поля не предусмотрено");
            }
            OnUpdated(DateTime.Now);
        } 

        public Book() { }

        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }

        public void OnUpdated(DateTime dt)
        {
            Updated?.Invoke(this, new ChangeArgs(dt));
        }

        public void OnAccessibilityChanged()
        {
            IsAvailable = !IsAvailable;
            if (IsAvailable) AccessibilityChanged?.Invoke(this, new EventArgs());
            OnUpdated(DateTime.Now);
        }
    }
}