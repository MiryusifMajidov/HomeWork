using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemTask.Helper
{
    public enum BookGenre
    {
        Fiction,
        NonFiction,
        Science,
        Art
    }
    public struct LibraryLocation
    {
        public int Aisle { get; set; }
        public int Shelf { get; set; }
    }

}
