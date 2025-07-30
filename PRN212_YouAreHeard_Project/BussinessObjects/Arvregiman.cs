using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class Arvregiman
{
    public int RegimenId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Duration { get; set; }

    public string? RegimenSideEffects { get; set; }

    public string? RegimenIndications { get; set; }

    public string? RegimenContraindications { get; set; }

    public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; } = new List<TreatmentPlan>();
}
