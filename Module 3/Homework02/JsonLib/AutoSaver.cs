using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonLib
{
    /// <summary>
    /// Automatically saves a list of books to a new file when the changes are made
    /// </summary>
    public class AutoSaver
    {
        private List<Book> books; // the list of books
        private DateTime lastUpdate; // time of the last update
        private string _originalJsonFileName; // original file name

        public AutoSaver(string originalJsonFileName, List<Book> books)
        {
            _originalJsonFileName = originalJsonFileName;
            this.books = books;


            lastUpdate = DateTime.Now; // setting the last update to the time of creating the instance of the class
            // Subscribing autoSaver to each book
            foreach (var book in books)
            {
                book.Updated += OnUpdatedEventHandler;
            }
        }

        /// <summary>
        /// Handles "Updated" event from "Book"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnUpdatedEventHandler (object? sender, ChangeArgs e)
        {
            // Checking if the timespan between lasst two changes is no greater then 15 seconds
            if (e.Dt - lastUpdate <= TimeSpan.FromSeconds(15))
            {
                File.WriteAllText($"../../../{_originalJsonFileName}_tmp.json", JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true }));
                Console.WriteLine("--------\nThe file was automatically updated.\n--------\n");
            }
            lastUpdate = e.Dt;
        }
    }
}
