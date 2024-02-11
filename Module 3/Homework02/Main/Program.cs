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
                    string value;
                    DateTime dt;
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
                    Console.WriteLine(dt);

                    List<Book> books = GetBooks(); // getting a list of book from .json

                    // creating and subsribing an auto saver
                    AutoSaver saver = new AutoSaver("11V", books);
                    foreach (Book book in books)
                    {
                        book.Updated += saver.OnUpdatedEventHandler;
                    }

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

                    switch (command)
                    {

                        case 1:
                            Console.WriteLine("Введите название поля без кавычек.\nВарианты: bookId, title, author, publicationYear, genre");
                            string field = Console.ReadLine() + ""; // given field

                            Console.WriteLine("1 - по возрастанию. (-1) - по убыванию");
                            int mode;
                            // input mode
                            while (true)
                            {

                                if (int.TryParse(Console.ReadLine(), out mode) && (mode == 1 || mode == -1)) break;
                                Console.WriteLine("Такой команды не существует. Повторите попытку.");
                            }

                            CollectionMethods.Sort(books, field, mode);
                            Console.WriteLine(JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true }));
                            break;

                        case 2:
                            Console.WriteLine("Введите ID книги для редактирования:");
                            string bookId; // given id
                            Book book;
                            while (true)
                            {
                                try
                                {
                                    bookId = Console.ReadLine() + "";
                                    book = CollectionMethods.FindBookById(books, bookId);
                                    break;
                                }
                                catch (ArgumentException)
                                {
                                    Console.WriteLine("Wrong input.");
                                } 
                            }

                            CollectionMethods.EditBook(book);
                            break;

                        case 3:
                            throw new Exception("Kill program");
                    }

                    /*WaitingList wl = new WaitingList(books.ElementAt(0));
                    wl.Subscribe("Anna");

                    

                    Book book1 = books.ElementAt(0);
                    Book book2 = books.ElementAt(1);
                    book1.ChangeField("title", "New Title");
                    book1.ChangeField("author", "New Author"); */

                    File.WriteAllText(@"../../../result.json", JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true }));

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

        static List<Book> GetBooks()
        {
            Console.WriteLine("Введите имя JSON-файла в папке, где лежит Program.cs (без указания расширения):");
            string path = $@"{Console.ReadLine()}.json";
            List<Book>? books = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(path), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (books == null) throw new ArgumentException("Файл не был корректно прочитан.");
            return books;
        }
    }
}