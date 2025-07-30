using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public string? Name { get; set; }

    public DateOnly? Dob { get; set; }

    public int? RoleId { get; set; }

    public bool? IsActive { get; set; }

    public string? Phone { get; set; }

    public string? FacebookPsid { get; set; }

    public virtual ICollection<Appointment> AppointmentDoctors { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentPatients { get; set; } = new List<Appointment>();

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual DoctorProfile? DoctorProfile { get; set; }

    public virtual ICollection<DoctorRating> DoctorRatings { get; set; } = new List<DoctorRating>();

    public virtual ICollection<LabResult> LabResultDoctors { get; set; } = new List<LabResult>();

    public virtual ICollection<LabResult> LabResultPatients { get; set; } = new List<LabResult>();

    public virtual ICollection<Otpverification> Otpverifications { get; set; } = new List<Otpverification>();

    public virtual PatientProfile? PatientProfile { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<SupportRequest> SupportRequestRepliedByNavigations { get; set; } = new List<SupportRequest>();

    public virtual ICollection<SupportRequest> SupportRequestUsers { get; set; } = new List<SupportRequest>();

    public virtual ICollection<TreatmentPlan> TreatmentPlanDoctors { get; set; } = new List<TreatmentPlan>();

    public virtual ICollection<TreatmentPlan> TreatmentPlanPatients { get; set; } = new List<TreatmentPlan>();
}
