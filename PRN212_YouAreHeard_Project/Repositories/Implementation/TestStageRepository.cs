using BussinessObjects;
using DataAccessLayer;
using Repository.Interface;
using System.Collections.Generic;

namespace Repository.Implementation
{
    public class TestStageRepository : ITestStageRepository
    {
        public List<TestStage> GetAll()
        {
            return TestStageDAO.GetAllTestStages();
        }

        public TestStage GetById(int id)
        {
            return TestStageDAO.GetById(id);
        }

        public void Add(TestStage testStage)
        {
            TestStageDAO.AddTestStage(testStage);
        }

        public void Update(TestStage testStage)
        {
            TestStageDAO.UpdateTestStage(testStage);
        }

        public void Delete(int id)
        {
            TestStageDAO.DeleteTestStage(id);
        }
    }
}
