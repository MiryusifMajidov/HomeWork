using AppointmentTask.Model;

namespace AppointmentTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //static void Main(string[] args)
            //{
            //    Console.OutputEncoding = System.Text.Encoding.UTF8;
            //    bool isTrue = true;

            //    while (isTrue)
            //    {
            //        Console.Clear();
            //        Console.WriteLine("""

            //            1. Appointment yarat
            //            2. Appointment-i bitir
            //            3. Bütün appointment-lərə bax
            //            4. Bu həftəki appointment-lərə bax
            //            5. Bugünki appointment-lərə bax
            //            6. Bitməmiş appointmentlərə bax
            //            7. Menudan çıx

            //            """);

            //        string choice = Console.ReadLine();

            //        switch (choice)
            //        {
            //            case "1":
            //                Console.WriteLine() ;
            //                break;
            //            case "2":
            //                Console.WriteLine();
            //                break;
            //            case "3":
            //                isTrue = false;
            //                return;
            //            default:
            //                Console.WriteLine("Yanlış seçim etdiniz.");
            //                break;
            //        }

            //        Console.WriteLine("Menyuya qayıtmaq üçün Enter düyməsini basın...");
            //        Console.ReadLine();
            //    }
            //}




            Appointment appointment = new Appointment();  
            appointment.StartDate = DateTime.Now;

            Console.WriteLine(appointment.StartDate.Day);
            
        }
    }
}
