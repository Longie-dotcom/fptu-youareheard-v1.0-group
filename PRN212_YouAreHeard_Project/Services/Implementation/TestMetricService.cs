using BussinessObjects;
using Repositories.Interface;
using Repositories.Implementation;
using Services.Interface;
using System.Collections.Generic;
using Repository.Implementation;
using Repository.Interface;

namespace Services.Implementation
{
    public class TestMetricService : ITestMetricService
    {
        private readonly ITestMetricRepository _testMetricRepository;

        public TestMetricService()
        {
            _testMetricRepository = new TestMetricRepository();
        }

        public List<TestMetric> GetTestMetricsByTypeId(int testTypeId)
        {
            return _testMetricRepository.GetTestMetricsByTypeId(testTypeId);
        }

        public List<TestMetric> GetAll()
        {
            return _testMetricRepository.GetAll();
        }

        public TestMetric GetById(int id)
        {
            return _testMetricRepository.GetById(id);
        }

        public void Add(TestMetric metric)
        {
            _testMetricRepository.Add(metric);
        }

        public void Update(TestMetric metric)
        {
            _testMetricRepository.Update(metric);
        }

        public void Delete(int id)
        {
            _testMetricRepository.Delete(id);
        }
    }
}
