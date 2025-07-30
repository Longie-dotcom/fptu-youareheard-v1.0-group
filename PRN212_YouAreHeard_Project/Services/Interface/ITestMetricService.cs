using BussinessObjects;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface ITestMetricService
    {
        List<TestMetric> GetAll();
        List<TestMetric> GetTestMetricsByTypeId(int testTypeId);
        TestMetric GetById(int id);
        void Add(TestMetric metric);
        void Update(TestMetric metric);
        void Delete(int id);
    }
}
