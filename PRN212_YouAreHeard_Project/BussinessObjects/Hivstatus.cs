using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class Hivstatus
{
    public int HivstatusId { get; set; }

    public string? HivstatusName { get; set; }

    public virtual ICollection<PatientProfile> PatientProfiles { get; set; } = new List<PatientProfile>();
}
