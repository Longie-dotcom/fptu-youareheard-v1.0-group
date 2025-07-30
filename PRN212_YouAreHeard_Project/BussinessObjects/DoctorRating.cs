using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class DoctorRating
{
    public int DoctorId { get; set; }

    public int UserId { get; set; }

    public int? RateValue { get; set; }

    public string? Description { get; set; }

    public virtual DoctorProfile Doctor { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
