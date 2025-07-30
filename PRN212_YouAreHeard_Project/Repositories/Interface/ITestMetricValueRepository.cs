using BussinessObjects;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface ITestMetricValueRepository
    {
        List<TestMetricValue> GetByLabResultId(int labResultId);
        void AddRange(List<TestMetricValue> values);
    }
}
