using BussinessObjects;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class PatientProfileRepository : IPatientProfileRepository
    {
        public void UpdateHIVStatus(int userId, int hivStatusId)
        {
            PatientProfileDAO.UpdateHivStatus(userId, hivStatusId);
        }
    }
}
