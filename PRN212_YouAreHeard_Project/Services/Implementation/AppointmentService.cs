using BussinessObjects;
using Enums;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        public List<Appointment> GetAllCurrentAppointmentsWithDetails(int doctorId)
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            return _appointmentRepository.GetAllAppointmentsWithDetails().
                FindAll(a => 
                a.DoctorId == doctorId 
                && a.AppointmentStatusId == AppointmentStatusEnum.CONFIRMED 
                && a.DoctorSchedule?.Date >= currentDate)
                .OrderBy(a => a.DoctorSchedule.Date).ToList();
        }

        public Appointment GetAppointmentByOrderCode(string orderCode)
        {
            return _appointmentRepository.GetAppointmentByOrderCode(orderCode);
        }
    }
}
