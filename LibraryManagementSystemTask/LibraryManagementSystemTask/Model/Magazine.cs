using LibraryManagementSystemTask.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemTask.Model
{
    public class Magazine : LibraryItem
    {
        public Magazine(string title, int? publicationYear):base(title, publicationYear) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Magazine: {Title}, Published: {PublicationYear}");
        }
    }

}
