using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class TestMetricValue
{
    public int LabResultId { get; set; }

    public int TestMetricId { get; set; }

    public string? Value { get; set; }

    public virtual LabResult LabResult { get; set; } = null!;

    public virtual TestMetric TestMetric { get; set; } = null!;
}
