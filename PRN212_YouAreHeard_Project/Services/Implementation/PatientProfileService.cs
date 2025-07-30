using BussinessObjects;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class PatientProfileService : IPatientProfileService
    {
        private readonly IPatientProfileRepository patientProfileRepository;

        public PatientProfileService()
        {
            patientProfileRepository = new PatientProfileRepository();
        }

        public void UpdateHIVStatus(int userId, int hivStatusId)
        {
            patientProfileRepository.UpdateHIVStatus(userId, hivStatusId);
        }
    }
}
