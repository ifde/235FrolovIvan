using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Book
    {
        private int _countPages; // the number of pages
        private int _sectionNumber; // tyhe number of the section in the library

        public int CountPages => _countPages;
        public int SectionNumber => _sectionNumber;

        public Book() { }
        public Book(int countPages, int sectionNumber)
        {
            if (countPages <= 0) throw new ArgumentOutOfRangeException();
            if (sectionNumber <= 0) throw new ArgumentOutOfRangeException();
            _countPages = countPages;
            _sectionNumber = sectionNumber;
        }

        public override string ToString()
        {
            return $"Книга в секции {SectionNumber}, количество страниц = {CountPages}";
        }
    }
}
