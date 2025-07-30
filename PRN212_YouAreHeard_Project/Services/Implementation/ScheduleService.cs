using BussinessObjects;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService()
        {
            _scheduleRepository = new ScheduleRepository();
        }

        public void AddDoctorScheduleRange(List<DoctorSchedule> list)
        {
            _scheduleRepository.AddDoctorScheduleRange(list);
        }

        public List<DoctorSchedule> GetSchedulesByDoctorId(int doctorId)
        {
            return _scheduleRepository.GetSchedulesByDoctorId(doctorId);
        }
    }
}
