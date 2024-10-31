using AppointmentTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTask.AppointmentService
{
    public class AppService : Appointment, IAppointmentInterface
    {
        List<Appointment> Appointments = new List<Appointment>();
        public AppService(string PatientName, string DoctorName) : base(PatientName, DoctorName)
        {
           
        }

        public void AddAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }

        public void EndAppointment(int id)
        {
            var endDate = Appointments[id].EndDate;

            if (endDate == null)
            {
                Console.WriteLine($"Gorusm hele bitmeyib. bitmesi ucun status deactiv olmalidir, hal hazirki status - {Appointments[id].statusEnum} ");
            }
            else 
            {
                Console.WriteLine(endDate);
            }

            
        }

        public void GetAppointment(int id)
        {
            Appointment appointment = Appointments[id];

            Console.WriteLine(appointment);
        }

        public void GetAllContinuingAppointments()
        {
           
        }

        public void GetAllAppointments()
        {
            foreach (var appointment in Appointments)
            {
                Console.WriteLine(appointment);
            }
        }

        public void GetTodaysAppointments()
        {
            foreach (var item in Appointments)
            {
                if (item.StartDate == DateTime.Now)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void GetWeeklyAppointments()
        {
            throw new NotImplementedException();
        }
    }
}
