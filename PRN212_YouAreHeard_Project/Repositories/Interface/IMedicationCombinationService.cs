using BussinessObjects;

namespace Services.Interface
{
    public interface IMedicationCombinationService
    {
        List<MedicationCombination> GetByRegimenId(int regimenId);
    }
}
