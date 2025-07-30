using BussinessObjects;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public List<Appointment> GetAllAppointmentsWithDetails()
        {
            return AppointmentDAO.GetAllAppointmentsWithDetails();
        }

        public Appointment GetAppointmentByOrderCode(string orderCode)
        {
            return AppointmentDAO.GetAppointmentByOrderCode(orderCode);
        }
    }
}
