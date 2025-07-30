using BussinessObjects;
using Repository.Implementation;
using Repository.Interface;
using Services.Interface;
using System.Collections.Generic;

namespace Services.Implementation
{
    public class TestMetricValueService : ITestMetricValueService
    {
        private readonly ITestMetricValueRepository _testMetricValueRepository;

        public TestMetricValueService()
        {
            _testMetricValueRepository = new TestMetricValueRepository();
        }

        public List<TestMetricValue> GetByLabResultId(int labResultId)
        {
            return _testMetricValueRepository.GetByLabResultId(labResultId);
        }

        public void AddRange(List<TestMetricValue> values)
        {
            _testMetricValueRepository.AddRange(values);
        }
    }
}
