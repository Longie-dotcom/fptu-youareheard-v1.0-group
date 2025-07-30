using BussinessObjects;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface ITestStageRepository
    {
        List<TestStage> GetAll();
        TestStage GetById(int id);
        void Add(TestStage testStage);
        void Update(TestStage testStage);
        void Delete(int id);
    }
}
