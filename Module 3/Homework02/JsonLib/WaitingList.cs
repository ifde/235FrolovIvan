using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonLib
{
    public class WaitingList
    {
        private readonly Book book;
        private readonly List<string> _subscribers;

        public WaitingList(Book book)
        {
            this.book = book;
            _subscribers = new List<string>();
        }

        public void Subscribe(string subscriber)
        {
            _subscribers.Add(subscriber);

            if (book.IsAvailable)
            {
                OnAccessibilityChangedEventHandler(book);
            }
        }

        private void OnAccessibilityChangedEventHandler(Book book)
        {
            foreach (string subscriber in _subscribers)
            {
                 Console.WriteLine($"{subscriber}, Теперь книгу {book.Title} можно забрать!"); 
            }
        }
    }
}
