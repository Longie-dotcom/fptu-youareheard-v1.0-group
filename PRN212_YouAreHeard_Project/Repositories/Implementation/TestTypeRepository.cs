using BussinessObjects;
using DataAccessLayer;
using Repository.Interface;
using System.Collections.Generic;

namespace Repository.Implementation
{
    public class TestTypeRepository : ITestTypeRepository
    {
        public List<TestType> GetAll()
        {
            return TestTypeDAO.GetAllTestTypes();
        }

        public TestType GetById(int id)
        {
            return TestTypeDAO.GetTestTypeById(id);
        }

        public void Add(TestType testType)
        {
            TestTypeDAO.AddTestType(testType);
        }

        public void Update(TestType testType)
        {
            TestTypeDAO.UpdateTestType(testType);
        }

        public void Delete(int id)
        {
            TestTypeDAO.DeleteTestType(id);
        }
    }
}
