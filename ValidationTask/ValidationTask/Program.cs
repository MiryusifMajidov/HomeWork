using System;
using ValidationLibrary;

namespace ValidationTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CustomValidator sinifindən obyekt yaradılır
            CustomValidator validator = new CustomValidator();

            // Parolu yoxlayırıq
            Console.Write("Istifadəçi adınızı daxil edin ");
            string username = Console.ReadLine();

            if (!validator.wordLength(username))
            {
                Console.WriteLine("username 2 herifden daha cox olmalidir");
                return;
            }

            Console.Write("adınızı daxil edin ");
            string name = Console.ReadLine();
            

            if (!validator.wordLength(name))
            {
                Console.WriteLine("name 2 herifden daha cox olmalidir");
                return;
            }


            Console.Write("Soyadınızı daxil edin ");
            string Surname = Console.ReadLine();

            if (!validator.wordLength(Surname))
            {
                Console.WriteLine("name 2 herifden daha cox olmalidir");
                return;
            }

            Console.Write("Yasiniz daxil edin ");
            string ageInput = Console.ReadLine();
            
            int age = int.Parse(ageInput);
            

            if (!validator.age(age))
            {
                Console.WriteLine("Yasiniz 0 dan boyuk olmalidir");
                return;
            }

            Console.Write("Dogum tarixiniz daxil edin ");
            string birthdayInput = Console.ReadLine();

            int birthday = int.Parse(birthdayInput);

            if (!validator.birthday(birthday))
            {
                Console.WriteLine("1970 den boyuk olmalidir");
                return;
            }

            Console.Write("Passwordunuz daxil edin ");
            string password = Console.ReadLine();

            if (!validator.ValidatePassword(password))
            {
                Console.WriteLine("Parol minimum 8 simvol olmalı, böyük hərf, kiçik hərf və rəqəm ehtiva etməlidir.");
                return;
            }

            Person person = new Person() 
            {
                Username = username,
                Password = password,
                Name = name,
                SureName = Surname,
                Age = age,
                Birthday = birthday
            };

            Console.WriteLine($"{person.Name} { person.SureName} {person.Username} adi ile person cedveline elave olundu ");

            
            



        }
    }
}
