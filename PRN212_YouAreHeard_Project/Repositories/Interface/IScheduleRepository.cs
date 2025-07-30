using BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IScheduleRepository
    {
        void AddDoctorScheduleRange(List<DoctorSchedule> list);
        List<DoctorSchedule> GetSchedulesByDoctorId(int doctorId);
    }
}
