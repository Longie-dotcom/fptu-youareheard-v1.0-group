using BussinessObjects;

namespace Services.Interface
{
    public interface IScheduleService
    {
        List<DoctorSchedule> GetSchedulesByDoctorId(int doctorId);
        void AddDoctorScheduleRange(List<DoctorSchedule> list);
    }
}
