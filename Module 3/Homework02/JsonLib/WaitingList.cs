using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonLib
{
    /// <summary>
    /// Represent's book's subscribers
    /// </summary>
    public class WaitingList
    {
        private readonly Book book;
        private readonly List<string> _subscribers;

        public WaitingList(Book book)
        {
            this.book = book;
            _subscribers = new List<string>();
            book.AccessibilityChanged += OnAccessibilityChangedEventHandler; // connecting the waiting list to the bok
        }

        /// <summary>
        /// Subscribes a person to a book
        /// </summary>
        /// <param name="subscriber"></param>
        public void Subscribe(string subscriber)
        {
            _subscribers.Add(subscriber);
        }

        /// <summary>
        /// Handles the AccessibilityChanged event from "Book"
        /// </summary>
        /// <param name="book"></param>
        private void OnAccessibilityChangedEventHandler(object? sender, EventArgs e)
        {
            foreach (string subscriber in _subscribers)
            {
                 Console.WriteLine($"{subscriber}, Теперь книгу {book.Title} можно забрать!"); 
            }
        }
    }
}
