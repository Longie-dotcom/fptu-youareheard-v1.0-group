using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class DoctorProfile
{
    public int UserId { get; set; }

    public string? Specialties { get; set; }

    public int? YearsOfExperience { get; set; }

    public string? Image { get; set; }

    public string? Gender { get; set; }

    public string? Description { get; set; }

    public string? LanguagesSpoken { get; set; }

    public virtual ICollection<DoctorRating> DoctorRatings { get; set; } = new List<DoctorRating>();

    public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();

    public virtual User User { get; set; } = null!;
}
