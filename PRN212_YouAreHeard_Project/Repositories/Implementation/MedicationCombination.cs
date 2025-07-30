using BussinessObjects;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class MedicationCombinationRepository : IMedicationCombinationRepository
    {
        public List<MedicationCombination> GetByRegimenId(int regimenId)
        {
            return MedicationCombinationDAO.GetByRegimenId(regimenId);
        }
    }
}
