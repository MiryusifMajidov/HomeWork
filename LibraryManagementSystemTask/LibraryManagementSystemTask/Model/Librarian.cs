using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemTask.Model
{
    public class Librarian : Person
    {
        public DateTime HireDate { get; set; }

        public Librarian(string name, DateTime hireDate) : base(name)
        {
            HireDate = hireDate;
        }
    }

}
