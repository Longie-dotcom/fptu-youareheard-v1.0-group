using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class TestMetricCombination
{
    public int? TestTypeId { get; set; }

    public int? TestMetricId { get; set; }

    public virtual TestMetric? TestMetric { get; set; }

    public virtual TestType? TestType { get; set; }
}
