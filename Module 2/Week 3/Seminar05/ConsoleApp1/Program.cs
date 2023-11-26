/*
Дисциплина: "Программирование"
Группа:      БПИ235(2)
Студент:     Фролов Иван Григорьевич
Задача:      Self01
 Дата:       26.11.2023
*/


using ClassLibrary;

namespace ConsoleApp1
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
                    Random rnd = new Random();
                    Library library;

                    Book[] books = new Book[rnd.Next(10, 21)];
                    for (int i = 0; i < books.Length; i++)
                    {
                        books[i] = new Book(rnd.Next(1, 501), rnd.Next(5, 11));
                        Console.WriteLine(books[i]);
                    }
                    library = new Library(books);

                    Console.WriteLine("\nКниги с количеством страниц, меньшим 200:");
                    foreach (Book book in library.GetBooksWithTheLessAmountOfPages(200))
                    {
                        Console.WriteLine(book);
                    }
                }
                catch
                {
                    Console.WriteLine("Возникла непредвиденная ошибка.");
                }

                Console.WriteLine("\n\n-------------\nНажмите ESC для завершения программы.\nДля повтора нажмите любую другую клавишу.\n-------------");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}