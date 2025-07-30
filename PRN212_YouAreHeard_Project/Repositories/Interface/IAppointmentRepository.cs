using BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IAppointmentRepository
    {
        public List<Appointment> GetAllAppointmentsWithDetails();
        public Appointment GetAppointmentByOrderCode(string orderCode);
    }
}
