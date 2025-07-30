using BussinessObjects;
using DataAccessLayer;
using Repository.Interface;
using System.Collections.Generic;

namespace Repository.Implementation
{
    public class TestMetricRepository : ITestMetricRepository
    {
        public List<TestMetric> GetAll()
        {
            return TestMetricDAO.GetAll();
        }

        public List<TestMetric> GetTestMetricsByTypeId(int testTypeId)
        {
            return TestMetricDAO.GetTestMetricsByTypeId(testTypeId);
        }

        public TestMetric GetById(int id)
        {
            return TestMetricDAO.GetById(id);
        }

        public void Add(TestMetric metric)
        {
            TestMetricDAO.Add(metric);
        }

        public void Update(TestMetric metric)
        {
            TestMetricDAO.Update(metric);
        }

        public void Delete(int id)
        {
            TestMetricDAO.Delete(id);
        }
    }
}
