using BussinessObjects;

namespace Repositories.Interface
{
    public interface IMedicationCombinationRepository
    {
        List<MedicationCombination> GetByRegimenId(int regimenId);
    }
}
