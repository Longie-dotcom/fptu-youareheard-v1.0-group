using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouAreHeard.Models
{
    public class AppointmentModel
    {
        public PatientProfileModel PatientProfile { get; set; }
        public int QueueNumber { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string ScheduleDate { get; set; }
        public string ScheduleTime { get; set; }
        public string Location { get; set; }
        public string Reason { get; set; }
        public string Notes { get; set; }
        public int AppointmentID {  get; set; }
    }
}
