using BussinessObjects;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class PillRemindTimeRepository : IPillRemindTimeRepository
    {
        public List<PillRemindTime> GetAllByTreatmentPlan(int treatmentPlanId)
        {
            return PillRemindTimeDAO.GetAllByTreatmentPlan(treatmentPlanId);
        }

        public void AddRange(List<PillRemindTime> times)
        {
            PillRemindTimeDAO.AddRange(times);
        }
    }
}
