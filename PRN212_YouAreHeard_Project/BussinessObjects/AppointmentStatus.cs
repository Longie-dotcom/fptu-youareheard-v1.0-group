using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class AppointmentStatus
{
    public int AppointmentStatusId { get; set; }

    public string? AppointmentStatusName { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
