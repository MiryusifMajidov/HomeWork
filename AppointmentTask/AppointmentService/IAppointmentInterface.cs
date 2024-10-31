using AppointmentTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTask.AppointmentService
{
    public interface IAppointmentInterface
    {
       
        

        public void AddAppointment(Appointment appointment);
        public void EndAppointment(int id);
        public void GetAppointment(int id);
        public void GetAllAppointments();
        public void GetWeeklyAppointments();
        public void GetTodaysAppointments();
        public void GetAllContinuingAppointments();
    }
}
