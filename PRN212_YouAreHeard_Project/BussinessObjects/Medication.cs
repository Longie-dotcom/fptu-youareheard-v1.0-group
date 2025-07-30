using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class Medication
{
    public int MedicationId { get; set; }

    public string? MedicationName { get; set; }

    public string? DosageMetric { get; set; }

    public string? SideEffect { get; set; }

    public string? Contraindications { get; set; }

    public string? Indications { get; set; }
}
