using BussinessObjects;
using DataAccessLayer;
using Repository.Interface;
using System.Collections.Generic;

namespace Repository.Implementation
{
    public class LabResultRepository : ILabResultRepository
    {
        public List<LabResult> GetAll()
        {
            return LabResultDAO.GetAll();
        }

        public LabResult GetById(int id)
        {
            return LabResultDAO.GetById(id);
        }

        public LabResult Add(LabResult labResult)
        {
            return LabResultDAO.Add(labResult);
        }

        public void Update(LabResult labResult)
        {
            LabResultDAO.Update(labResult);
        }

        public void Delete(int id)
        {
            LabResultDAO.Delete(id);
        }
    }
}
