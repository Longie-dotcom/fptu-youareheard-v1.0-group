using BussinessObjects;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface ITestTypeRepository
    {
        List<TestType> GetAll();
        TestType GetById(int id);
        void Add(TestType testType);
        void Update(TestType testType);
        void Delete(int id);
    }
}
