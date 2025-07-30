using BussinessObjects;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface ITestMetricValueService
    {
        List<TestMetricValue> GetByLabResultId(int labResultId);
        void AddRange(List<TestMetricValue> values);
    }
}
