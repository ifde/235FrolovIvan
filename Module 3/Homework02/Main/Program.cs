/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      КДЗ-2 (3 модуль)
Вариант:     11
Дата:        10.02.24
*/


using JsonLib;
using System.Text.Json;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFileName = @"../../../11V.json";

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonFileName, options) ?? new List<Book>();

            AutoSaver saver = new AutoSaver("11V", books);
            WaitingList wl = new WaitingList(books.ElementAt(0));
            wl.Subscribe("Anna");

            foreach (Book book in books)
            {
                book.Updated += saver.OnUpdatedEventHandler;
            }

            Book book1 = books.ElementAt(0);
            Book book2 = books.ElementAt(1);
            book1.ChangeField("title", "New Title");
            book1.ChangeField("author", "New Author");

           File.WriteAllText(@"../../../result.json", JsonSerializer.Serialize(books));
        }
    }
}