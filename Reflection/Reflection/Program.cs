using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Type userType = typeof(User);

           
            object userInstance = Activator.CreateInstance(userType);

            // Property-lərin Reflection ilə əldə edilməsi
            PropertyInfo idProperty = userType.GetProperty("Id");
            PropertyInfo nameProperty = userType.GetProperty("Name");
            PropertyInfo surnameProperty = userType.GetProperty("Surname");
            PropertyInfo ageProperty = userType.GetProperty("Age");

            
             idProperty.SetValue(userInstance, 1);  
            nameProperty.SetValue(userInstance, "miri");
            surnameProperty.SetValue(userInstance, "majidov");

           
            ageProperty.SetValue(null, 19);

            
            Console.WriteLine("Məlumatlar:");
            Console.WriteLine($"Id: {idProperty.GetValue(userInstance)}");
            Console.WriteLine($"Name: {nameProperty.GetValue(userInstance)}");
            Console.WriteLine($"Surname: {surnameProperty.GetValue(userInstance)}");
            Console.WriteLine($"Age: {ageProperty.GetValue(null)}");

           
            Console.WriteLine("GetFullName method:");
            MethodInfo getFullNameMethod = userType.GetMethod("GetFullName");
            getFullNameMethod.Invoke(userInstance, null);

          
            Console.WriteLine("ChangeAge method:");
            MethodInfo changeAgeMethod = userType.GetMethod("ChangeAge");
            changeAgeMethod.Invoke(null, new object[] { 30 });

           
            Console.WriteLine($"New Age: {ageProperty.GetValue(null)}");
        }
    }
}
