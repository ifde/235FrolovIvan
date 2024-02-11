using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonLib
{
    public class AutoSaver
    {
        private readonly List<Book> books;
        private readonly DateTime lastUpdate;
        private readonly string _originalJsonFileName;

        public AutoSaver(string originalJsonFileName, List<Book> books)
        {
            _originalJsonFileName = originalJsonFileName;
            this.books = books;


            lastUpdate = DateTime.Now;
            foreach (var book in books)
            {
                book.Updated += OnUpdatedEventHandler;
            }
        }

        public void OnUpdatedEventHandler (object? sender, ChangeArgs e)
        {
            if (e.Dt - lastUpdate <= TimeSpan.FromSeconds(15))
            {
                File.WriteAllText($"../../../{_originalJsonFileName}_tmp.json", JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true }));
            }
        }
    }
}
