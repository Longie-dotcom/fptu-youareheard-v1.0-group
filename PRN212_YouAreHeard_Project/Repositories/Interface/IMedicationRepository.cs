using BussinessObjects;

namespace Repositories.Interface
{
    public interface IMedicationRepository
    {
        List<Medication> GetAll();
        Medication? GetById(int id);
    }
}
