using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class DoctorScheduleStatus
{
    public int DoctorScheduleStatusId { get; set; }

    public string? DoctorScheduleStatusName { get; set; }

    public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();
}
