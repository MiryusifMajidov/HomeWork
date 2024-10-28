using LibraryManagementSystemTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemTask.Helper
{
    public interface ILibrarianService
    {
        Librarian GetLibrarianById(int id);
        Librarian[] GetAllLibrarians();
        void CreateLibrarian(Librarian librarian);
        void DeleteLibrarian(Librarian librarian, bool isSoftDelete);
    }

}
