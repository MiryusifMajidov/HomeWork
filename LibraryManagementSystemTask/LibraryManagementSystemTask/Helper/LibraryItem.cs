using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemTask.Helper
{
    public abstract class LibraryItem
    {
        public string Title { get; private set; }
        public int? PublicationYear { get; set; }

        protected LibraryItem(string title, int? publicationYear = null)
        {
            Title = title;
            PublicationYear = publicationYear;
        }

        public abstract void DisplayInfo();
    }

}
