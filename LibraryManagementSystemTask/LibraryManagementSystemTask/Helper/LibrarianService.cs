using LibraryManagementSystemTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemTask.Helper
{
    public class LibrarianService : ILibrarianService
    {
        private Librarian[] _librarians = new Librarian[0];

        public Librarian GetLibrarianById(int id)
        {
            foreach (var librarian in _librarians)
            {
                if (librarian.Id == id)
                {
                    return librarian;
                }
            }
            return null;
        }


        public Librarian[] GetAllLibrarians()
        {
            return _librarians;
        }

        public void CreateLibrarian(Librarian librarian)
        {
            Array.Resize(ref _librarians, _librarians.Length + 1);
            _librarians[^1] = librarian; 
        }

        public void DeleteLibrarian(Librarian librarian, bool isSoftDelete)
        {
            int index = Array.IndexOf(_librarians, librarian);

            if (index == -1) return;

            if (isSoftDelete)
            {
                Console.WriteLine("deaktiv edildi");
            }
            else
            {
               
                Librarian[] newLibrarians = new Librarian[_librarians.Length - 1];

                for (int i = 0, j = 0; i < _librarians.Length; i++)
                {
                    if (i != index)
                    {
                        newLibrarians[j] = _librarians[i];
                        j++;
                    }
                }

                _librarians = newLibrarians;

                Console.WriteLine("birdefelik silindi");
            }
        }


    }

}
