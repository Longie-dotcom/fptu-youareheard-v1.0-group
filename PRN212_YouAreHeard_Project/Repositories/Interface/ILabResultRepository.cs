using BussinessObjects;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface ILabResultRepository
    {
        List<LabResult> GetAll();
        LabResult GetById(int id);
        LabResult Add(LabResult labResult);
        void Update(LabResult labResult);
        void Delete(int id);
    }
}
