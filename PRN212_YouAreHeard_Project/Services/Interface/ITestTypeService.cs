using BussinessObjects;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface ITestTypeService
    {
        List<TestType> GetAll();
        TestType GetById(int id);
        void Add(TestType testType);
        void Update(TestType testType);
        void Delete(int id);
    }
}
