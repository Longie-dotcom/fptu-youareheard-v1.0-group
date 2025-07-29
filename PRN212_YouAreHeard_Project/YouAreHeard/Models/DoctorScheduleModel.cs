using System;

namespace YouAreHeard.Models
{
    public class DoctorScheduleModel
    {
        public int DoctorScheduleId { get; set; }
        public string? Location { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public DateOnly? Date { get; set; }
        public string? StatusName { get; set; }
    }
}
