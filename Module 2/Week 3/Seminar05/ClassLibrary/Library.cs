namespace ClassLibrary
{
    public class Library
    {
        private int booksNum; // number of book in the library
        private List<Book> books  = new List<Book>(0); // an array of books in the library

        public int BooksNum => booksNum;
        public Library() { }

        public Library(Book[] books)
        {
            foreach (var book in books)
            {
                this.books.Add(book);
            }
            booksNum = books.Length;
        }

        /// <summary>
        /// Adds the book to the library
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            books.Add(book);
            booksNum += 1;
        }

        public Book[] GetBooksWithTheLessAmountOfPages (int n)
        {
            Book[] books = new Book[booksNum]; // method output
            int k = 0; // the length of books[]. Updates each iteration.

            foreach (var book in this.books)
            {
                if (book.CountPages < n) books[k++] = book;
            }
            Array.Resize(ref books, k);
            return books;
        }

        public override string ToString()
        {
            return $"В библиотеке {booksNum} книг.";
        }

    }
}