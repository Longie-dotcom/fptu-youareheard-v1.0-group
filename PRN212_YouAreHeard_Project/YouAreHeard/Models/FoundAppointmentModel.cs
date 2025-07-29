namespace YouAreHeard.Models
{
    public class FoundAppointmentModel
    {
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public string ScheduleDate { get; set; }
        public string ScheduleTime { get; set; }
        public string Location { get; set; }
        public string IsOnline { get; set; } // "Trực tuyến" or "Trực tiếp"
        public int QueueNumber { get; set; }
    }
}
