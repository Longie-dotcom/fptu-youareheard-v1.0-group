using BussinessObjects;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class MedicationRepository : IMedicationRepository
    {
        public List<Medication> GetAll()
        {
            return MedicationDAO.GetAll();
        }

        public Medication? GetById(int id)
        {
            return MedicationDAO.GetById(id);
        }
    }
}
