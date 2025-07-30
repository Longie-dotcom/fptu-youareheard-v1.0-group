using BussinessObjects;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository;

        public MedicationService()
        {
            _medicationRepository = new MedicationRepository();
        }

        public List<Medication> GetAll()
        {
            return _medicationRepository.GetAll();
        }

        public Medication? GetById(int id)
        {
            return _medicationRepository.GetById(id);
        }
    }
}
