namespace YouAreHeard.Models
{
    public class TestMetricModel
    {
        public int TestMetricID { get; set; }
        public string TestMetricName { get; set; }
        public string TestMetricTypeName { get; set; }
        public string UnitName { get; set; }

        // Input value for test result
        public string Value { get; set; } = string.Empty;
    }
}
