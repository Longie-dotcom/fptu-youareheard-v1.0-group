using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class TreatmentPlan
{
    public int TreatmentPlanId { get; set; }

    public int? RegimenId { get; set; }

    public int? DoctorId { get; set; }

    public int? PatientId { get; set; }

    public DateTime? Date { get; set; }

    public string? Notes { get; set; }

    public bool? IsCustomized { get; set; }

    public virtual User? Doctor { get; set; }

    public virtual User? Patient { get; set; }

    public virtual Arvregiman? Regimen { get; set; }
}
