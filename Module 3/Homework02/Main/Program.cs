/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      КДЗ-2 (3 модуль)
Вариант:     11
Дата:        10.02.24
*/


using JsonLib;
using System.Globalization;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // repeat program
            do
            {
                Console.Clear();

                try
                {

                    List<Book> books = CollectionMethods.GetBooks(); // getting a list of books from .json

                    /* Book tmp = books.ElementAt(0);
                    WaitingList wl = new WaitingList(tmp);
                    wl.Subscribe("Anna");


                    tmp.OnAccessibilityChanged(); */

                    // creating an auto saver
                    AutoSaver saver = new AutoSaver("11V", books);

                    while (true)
                    {
                        int command = CollectionMethods.GetCommandMenu1();
                        switch (command)
                        {

                            case 1:

                                string field = CollectionMethods.GetField("bookId", "title", "author", "publicationYear", "genre");
                                int mode = CollectionMethods.GetMode();

                                CollectionMethods.Sort(books, field, mode);

                                Console.WriteLine(JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true }));
                                break;

                            case 2:

                                Book book = CollectionMethods.GetBookById(books);

                                CollectionMethods.EditBook(book);
                                Console.WriteLine(book.ToJSON());
                                break;

                            case 3:
                                throw new Exception("Kill program");
                        }

                    }

                    

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    if (e.Message != "Kill program") Console.WriteLine("Возникла непредвиденная ошибка.");
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }


    }
}