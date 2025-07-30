using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class MedicationCombination
{
    public int? MedicationId { get; set; }

    public int? RegimenId { get; set; }

    public int? Frequency { get; set; }

    public int? Dosage { get; set; }

    public virtual Medication? Medication { get; set; }

    public virtual Arvregiman? Regimen { get; set; }
}
