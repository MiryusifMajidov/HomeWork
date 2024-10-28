using LibraryManagementSystemTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemTask.Helper
{
    public class CustomBookError : Exception
    {
        public CustomBookError(string message) : base(message) { }
    }

    public class LibraryCatalog
    {
        private Book[] _books;
        private int _currentId = 0;

        public LibraryCatalog(int initialCapacity)
        {
            _books = new Book[initialCapacity];
        }

        public Book this[int id]
        {
            get
            {
                if (id < 0 || id >= _currentId || _books[id] == null)
                {
                    throw new CustomBookError($" {id}  idli kitab tapilmadi");
                }
                return _books[id];
            }
        }

       
        public void AddBook(Book book)
        {
           
            if (_currentId >= _books.Length)
            {
                Array.Resize(ref _books, _books.Length + 1);
            }

            
            _books[_currentId] = book;
            _currentId++;
        }
    }


}
