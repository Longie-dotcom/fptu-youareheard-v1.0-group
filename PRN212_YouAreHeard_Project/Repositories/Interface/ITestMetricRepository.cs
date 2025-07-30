using BussinessObjects;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface ITestMetricRepository
    {
        List<TestMetric> GetAll();
        TestMetric GetById(int id);
        List<TestMetric> GetTestMetricsByTypeId(int testTypeId);
        void Add(TestMetric metric);
        void Update(TestMetric metric);
        void Delete(int id);
    }
}
