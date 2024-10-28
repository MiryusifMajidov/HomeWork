using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemTask.Helper
{
    public static class LibraryHelper
    {
        public static int CalculateAge(this LibraryItem item)
        {
            return item.PublicationYear.HasValue ? DateTime.Now.Year - item.PublicationYear.Value : 0;
        }

        public static string ToTitleCase(this LibraryItem item)
        {
            
            string output = item.Title.ToLower();  
            output = char.ToUpper(output[0]) + output.Substring(1); 

            return output;
        }
    }

}
