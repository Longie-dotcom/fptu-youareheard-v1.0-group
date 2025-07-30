using BussinessObjects;
using Repositories.Interface;
using Repositories.Implementation;
using Services.Interface;
using System.Collections.Generic;
using Repository.Implementation;
using Repository.Interface;

namespace Services.Implementation
{
    public class TestStageService : ITestStageService
    {
        private readonly ITestStageRepository _testStageRepository;

        public TestStageService()
        {
            _testStageRepository = new TestStageRepository();
        }

        public List<TestStage> GetAll()
        {
            return _testStageRepository.GetAll();
        }

        public TestStage GetById(int id)
        {
            return _testStageRepository.GetById(id);
        }

        public void Add(TestStage stage)
        {
            _testStageRepository.Add(stage);
        }

        public void Update(TestStage stage)
        {
            _testStageRepository.Update(stage);
        }

        public void Delete(int id)
        {
            _testStageRepository.Delete(id);
        }
    }
}
