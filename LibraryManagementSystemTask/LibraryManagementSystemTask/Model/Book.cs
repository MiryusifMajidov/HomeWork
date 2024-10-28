using LibraryManagementSystemTask.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemTask.Model
{
    public class Book : LibraryItem
    {
        public BookGenre Genre { get; set; }
        public LibraryLocation Location { get; set; }

        public Book(string title, int? publicationYear, BookGenre genre, LibraryLocation location):base(title, publicationYear)
        {
            Genre = genre;
            Location = location;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Book: {Title}, Janr: {Genre}, Published: {PublicationYear}, Location: Kolidor {Location.Aisle}, Ref {Location.Shelf}");
        }
    }
}
