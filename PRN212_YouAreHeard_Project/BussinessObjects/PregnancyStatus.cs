using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class PregnancyStatus
{
    public int PregnancyStatusId { get; set; }

    public string? PregnancyStatusName { get; set; }

    public virtual ICollection<PatientProfile> PatientProfiles { get; set; } = new List<PatientProfile>();
}
