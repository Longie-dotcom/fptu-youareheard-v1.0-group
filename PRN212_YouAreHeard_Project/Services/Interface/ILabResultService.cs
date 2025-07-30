using BussinessObjects;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface ILabResultService
    {
        List<LabResult> GetAll();
        LabResult GetById(int id);
        LabResult Add(LabResult labResult);
        void Update(LabResult labResult);
        void Delete(int id);
    }
}
