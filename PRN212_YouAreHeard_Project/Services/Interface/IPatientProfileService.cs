using BussinessObjects;

namespace Services.Interface
{
    public interface IPatientProfileService
    {
        public void UpdateHIVStatus(int userId, int hivStatusId);
    }
}
