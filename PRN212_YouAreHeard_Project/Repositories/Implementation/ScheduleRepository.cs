using BussinessObjects;
using DataAccessLayer;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class ScheduleRepository : IScheduleRepository
    {
        public void AddDoctorScheduleRange(List<DoctorSchedule> list)
        {
            DoctorScheduleDAO.AddDoctorScheduleRange(list);
        }

        public List<DoctorSchedule> GetSchedulesByDoctorId(int doctorId)
        {
            return DoctorScheduleDAO.GetSchedulesByDoctorId(doctorId);
        }
    }
}
