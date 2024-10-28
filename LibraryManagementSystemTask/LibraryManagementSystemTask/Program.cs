using LibraryManagementSystemTask.Helper;
using LibraryManagementSystemTask.Model;

namespace LibraryManagementSystemTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            ILibrarianService librarianService = new LibrarianService();

            var librarian1 = new Librarian("Miri", DateTime.Now.AddYears(-5)) ;
            var librarian2 = new Librarian("YUsif", DateTime.Now.AddYears(-3)) ;
            var librarian3 = new Librarian("Davud", DateTime.Now.AddYears(-1)) ;

            librarianService.CreateLibrarian(librarian1);
            librarianService.CreateLibrarian(librarian2);
            librarianService.CreateLibrarian(librarian3);

           
            Console.WriteLine("Butun kitabxanacilar:");
            foreach (var librarian in librarianService.GetAllLibrarians())
            {
                Console.WriteLine($"ID: {librarian.Id}, Name: {librarian.Name}, Hire Date: {librarian.HireDate}");
            }

            
            int searchId = 2;
            var foundLibrarian = librarianService.GetLibrarianById(searchId);
            if (foundLibrarian != null)
            {
                Console.WriteLine($" Axtardiginiz id {searchId}: Name: {foundLibrarian.Name}, Hire Date: {foundLibrarian.HireDate}");
            }
            else
            {
                Console.WriteLine($"bu idli melumat tapilmadi {searchId}");
            }

            
            
            librarianService.DeleteLibrarian(librarian2, true);

            
            foundLibrarian = librarianService.GetLibrarianById(searchId);
            if (foundLibrarian != null)
            {
                Console.WriteLine($"\nFound Librarian with ID {searchId} after soft delete: Name: {foundLibrarian.Name}, Hire Date: {foundLibrarian.HireDate}");
            }

          
            Console.WriteLine("\nAll Librarians After Deletion:");
            foreach (var librarian in librarianService.GetAllLibrarians())
            {
                Console.WriteLine($"ID: {librarian.Id}, Name: {librarian.Name}, Hire Date: {librarian.HireDate}");
            }
        }
    }
}
