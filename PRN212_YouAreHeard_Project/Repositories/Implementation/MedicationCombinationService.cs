using BussinessObjects;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class MedicationCombinationService : IMedicationCombinationService
    {
        private readonly IMedicationCombinationRepository _repository;

        public MedicationCombinationService()
        {
            _repository = new MedicationCombinationRepository();
        }

        public List<MedicationCombination> GetByRegimenId(int regimenId)
        {
            return _repository.GetByRegimenId(regimenId);
        }
    }
}
