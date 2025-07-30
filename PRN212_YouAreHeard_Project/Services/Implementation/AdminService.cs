using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService()
        {
            _adminRepository = new AdminRepository();
        }

        public int GetTotalUserCount()
        {
            return _adminRepository.GetTotalUserCount();
        }

        public int GetTotalDoctorCount()
        {
            return _adminRepository.GetTotalDoctorCount();
        }

        public int GetTotalPatientCount()
        {
            return _adminRepository.GetTotalPatientCount();
        }

        public int GetTotalAppointmentCount()
        {
            return _adminRepository.GetTotalAppointmentCount();
        }

        public int GetActiveTreatmentPlanCount()
        {
            return _adminRepository.GetActiveTreatmentPlanCount();
        }

        public int GetTotalLabResultCount()
        {
            return _adminRepository.GetTotalLabResultCount();
        }

        public int GetTotalConfirmedAppointments()
        {
            return _adminRepository.GetConfirmedAppointmentCount();
        }

        public int GetTotalCompletedAppointments()
        {
            return _adminRepository.GetCompletedAppointmentCount();
        }

        public int GetTotalCancelledAppointments()
        {
            return _adminRepository.GetCancelledAppointmentCount();
        }

        public int GetTotalPendingAppointments()
        {
            return _adminRepository.GetPendingAppointmentCount();
        }

        public int GetTotalVerifiedAccount()
        {
            return _adminRepository.GetTotalVerifiedAccount();
        }

        public int GetTotalUnverifiedAccount()
        {
            return _adminRepository.GetTotalUnverifiedAccount();
        }
    }
}
