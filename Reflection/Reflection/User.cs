using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class User
    {
       
        public int Id { get; private set; }

        public string Name { get; private set; }
  
        public string Surname { get; private set; }

        public static int Age { get; private set; }
        public User() { }
        public User(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

      
        public void GetFullName()
        {
            Console.WriteLine($"{Name} {Surname}");
        }

       
        public static void ChangeAge(int newAge)
        {
            Age = newAge;
        }
    }

}
