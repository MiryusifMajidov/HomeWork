using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTask.Model
{
    public class Appointment
    {
        public enum StatusEnum
        {
            waiting,
            active,
            deactive
        }

        public static int id {
            get {  return id; }
            set
            {
                id++;
            }
        }
        public int No { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public StatusEnum statusEnum { get; set; }
        public Appointment(string PatientName, string DoctorName)
        {
            No = id;
            this.PatientName = PatientName;
            this.DoctorName = DoctorName;
            StartDate = DateTime.Now;   
            EndDate = null;
            statusEnum = StatusEnum.waiting;

        }
        public Appointment()
        {
            
        }

    }
}
