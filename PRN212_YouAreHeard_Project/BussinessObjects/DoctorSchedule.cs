using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class DoctorSchedule
{
    public int DoctorScheduleId { get; set; }

    public int? UserId { get; set; }

    public string? Location { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public int? DoctorScheduleStatusId { get; set; }

    public DateOnly? Date { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual DoctorScheduleStatus? DoctorScheduleStatus { get; set; }

    public virtual DoctorProfile? User { get; set; }
}
