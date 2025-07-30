using BussinessObjects;
using Repositories.Interface;
using Repositories.Implementation;
using Services.Interface;
using System.Collections.Generic;
using Repository.Implementation;
using Repository.Interface;

namespace Services.Implementation
{
    public class TestTypeService : ITestTypeService
    {
        private readonly ITestTypeRepository _testTypeRepository;

        public TestTypeService()
        {
            _testTypeRepository = new TestTypeRepository();
        }

        public List<TestType> GetAll()
        {
            return _testTypeRepository.GetAll();
        }

        public TestType GetById(int id)
        {
            return _testTypeRepository.GetById(id);
        }

        public void Add(TestType testType)
        {
            _testTypeRepository.Add(testType);
        }

        public void Update(TestType testType)
        {
            _testTypeRepository.Update(testType);
        }

        public void Delete(int id)
        {
            _testTypeRepository.Delete(id);
        }
    }
}
