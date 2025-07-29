using System.Collections.Generic;

namespace YouAreHeard.Models
{
    public class TestTypeModel
    {
        public int TestTypeId { get; set; }
        public string TestTypeName { get; set; }
        public List<TestMetricModel>? TestMetrics { get; set; } = new();
    }
}
