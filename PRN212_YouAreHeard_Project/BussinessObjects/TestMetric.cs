using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class TestMetric
{
    public int TestMetricId { get; set; }

    public int? TestMetricTypeId { get; set; }

    public string? TestMetricName { get; set; }

    public string? UnitName { get; set; }

    public virtual TestMetricType? TestMetricType { get; set; }

    public virtual ICollection<TestMetricValue> TestMetricValues { get; set; } = new List<TestMetricValue>();
}
