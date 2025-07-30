namespace Repositories.Interface
{
    public interface IAdminRepository
    {
        int GetTotalUserCount();
        int GetTotalDoctorCount();
        int GetTotalPatientCount();
        int GetTotalAppointmentCount();
        int GetActiveTreatmentPlanCount();
        int GetTotalLabResultCount();
        int GetConfirmedAppointmentCount();
        int GetCompletedAppointmentCount();
        int GetCancelledAppointmentCount();
        int GetPendingAppointmentCount();
        int GetTotalVerifiedAccount();
        int GetTotalUnverifiedAccount();
    }
}
