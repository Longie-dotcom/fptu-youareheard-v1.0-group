using BussinessObjects;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface ITestStageService
    {
        List<TestStage> GetAll();
        TestStage GetById(int id);
        void Add(TestStage stage);
        void Update(TestStage stage);
        void Delete(int id);
    }
}
