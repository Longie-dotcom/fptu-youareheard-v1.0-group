using BussinessObjects;
using DataAccessLayer;
using Repository.Interface;
using System.Collections.Generic;

namespace Repository.Implementation
{
    public class TestMetricValueRepository : ITestMetricValueRepository
    {
        public List<TestMetricValue> GetByLabResultId(int labResultId)
        {
            return TestMetricValueDAO.GetByLabResultId(labResultId);
        }

        public void AddRange(List<TestMetricValue> values)
        {
            TestMetricValueDAO.AddRange(values);
        }
    }
}
