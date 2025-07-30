using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class LabResult
{
    public int LabResultId { get; set; }

    public int? DoctorId { get; set; }

    public int? PatientId { get; set; }

    public int? TestStageId { get; set; }

    public int? TestTypeId { get; set; }

    public string? Notes { get; set; }

    public DateTime? Date { get; set; }

    public bool? IsCustomized { get; set; }

    public virtual User? Doctor { get; set; }

    public virtual User? Patient { get; set; }

    public virtual ICollection<TestMetricValue> TestMetricValues { get; set; } = new List<TestMetricValue>();

    public virtual TestStage? TestStage { get; set; }

    public virtual TestType? TestType { get; set; }
}
