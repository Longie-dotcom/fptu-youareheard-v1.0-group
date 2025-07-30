using BussinessObjects;

namespace Services.Interface
{
    public interface IAppointmentService
    {
        List<Appointment> GetAllCurrentAppointmentsWithDetails(int doctorId);
        Appointment GetAppointmentByOrderCode(string orderCode);
    }
}
