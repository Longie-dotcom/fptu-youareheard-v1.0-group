using BussinessObjects;

namespace Repositories.Interface
{
    public interface IPatientProfileRepository
    {
        void UpdateHIVStatus(int userId, int hivStatusId);
    }
}
