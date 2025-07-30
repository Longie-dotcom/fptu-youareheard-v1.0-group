using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class TestMetricType
{
    public int TestMetricTypeId { get; set; }

    public string? TestMetricTypeName { get; set; }

    public virtual ICollection<TestMetric> TestMetrics { get; set; } = new List<TestMetric>();
}
