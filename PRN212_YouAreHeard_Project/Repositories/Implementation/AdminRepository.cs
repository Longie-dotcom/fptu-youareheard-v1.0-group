using BussinessObjects;
using DAO;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class AdminRepository : IAdminRepository
    {
        public int GetTotalUserCount()
        {
            return AdminDAO.GetTotalUserCount();
        }

        public int GetTotalDoctorCount()
        {
            return AdminDAO.GetTotalDoctorCount();
        }

        public int GetTotalPatientCount()
        {
            return AdminDAO.GetTotalPatientCount();
        }

        public int GetTotalAppointmentCount()
        {
            return AdminDAO.GetTotalAppointmentCount();
        }

        public int GetActiveTreatmentPlanCount()
        {
            return AdminDAO.GetActiveTreatmentPlanCount();
        }

        public int GetTotalLabResultCount()
        {
            return AdminDAO.GetTotalLabResultCount();
        }

        public int GetConfirmedAppointmentCount()
        {
            return AdminDAO.GetConfirmedAppointmentCount();
        }

        public int GetCompletedAppointmentCount()
        {
            return AdminDAO.GetCompletedAppointmentCount();
        }

        public int GetCancelledAppointmentCount()
        {
            return AdminDAO.GetCancelledAppointmentCount();
        }

        public int GetPendingAppointmentCount()
        {
            return AdminDAO.GetPendingAppointmentCount();
        }

        public int GetTotalVerifiedAccount()
        {
            return AdminDAO.GetTotalVerifiedAccount();
        }

        public int GetTotalUnverifiedAccount()
        {
            return AdminDAO.GetTotalUnverifiedAccount();
        }
    }
}
