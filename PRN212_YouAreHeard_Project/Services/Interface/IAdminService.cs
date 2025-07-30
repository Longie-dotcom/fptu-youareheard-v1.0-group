namespace Services.Interface
{
    public interface IAdminService
    {
        int GetTotalUserCount();
        int GetTotalDoctorCount();
        int GetTotalPatientCount();
        int GetTotalAppointmentCount();
        int GetActiveTreatmentPlanCount();
        int GetTotalLabResultCount();
        int GetTotalConfirmedAppointments();
        int GetTotalCompletedAppointments();
        int GetTotalCancelledAppointments();
        int GetTotalPendingAppointments();
        int GetTotalVerifiedAccount();
        int GetTotalUnverifiedAccount();
    }
}
