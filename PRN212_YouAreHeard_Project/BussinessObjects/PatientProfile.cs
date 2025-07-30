using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class PatientProfile
{
    public int UserId { get; set; }

    public int? HivStatusId { get; set; }

    public int? PregnancyStatusId { get; set; }

    public double? Height { get; set; }

    public double? Weight { get; set; }

    public string? Gender { get; set; }

    public virtual Hivstatus? HivStatus { get; set; }

    public virtual PregnancyStatus? PregnancyStatus { get; set; }

    public virtual User User { get; set; } = null!;
}
