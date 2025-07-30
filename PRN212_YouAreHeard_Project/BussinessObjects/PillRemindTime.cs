using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class PillRemindTime
{
    public int PillRemindTimeId { get; set; }
    public int? TreatmentPlanId { get; set; }

    public TimeOnly? Time { get; set; }

    public int? MedicationId { get; set; }

    public int? DrinkDosage { get; set; }

    public string? Notes { get; set; }

    public virtual Medication? Medication { get; set; }

    public virtual TreatmentPlan? TreatmentPlan { get; set; }
}
