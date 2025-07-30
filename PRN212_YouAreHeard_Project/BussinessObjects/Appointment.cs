using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? DoctorId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorScheduleId { get; set; }

    public int? AppointmentStatusId { get; set; }

    public string? ZoomLink { get; set; }

    public string? Notes { get; set; }

    public string? DoctorNotes { get; set; }

    public string? Reason { get; set; }

    public bool? IsAnonymous { get; set; }

    public bool? IsOnline { get; set; }

    public int? QueueNumber { get; set; }

    public string? OrderCode { get; set; }

    public DateTime? Date { get; set; }

    public virtual AppointmentStatus? AppointmentStatus { get; set; }

    public virtual User? Doctor { get; set; }

    public virtual DoctorSchedule? DoctorSchedule { get; set; }

    public virtual User? Patient { get; set; }
}
