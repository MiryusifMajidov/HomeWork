using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemTask.Model
{
    public abstract class Person
    {
        private static int _idCounter = 0; 

        public int Id { get; private set; }
        public string Name { get; private set; }

        protected Person(string name)
        {
            Id = ++_idCounter; 
            Name = name;
        }
    }


}
