using BussinessObjects;

namespace Repositories.Interface
{
    public interface IPillRemindTimeRepository
    {
        List<PillRemindTime> GetAllByTreatmentPlan(int treatmentPlanId);
        void AddRange(List<PillRemindTime> times);
    }
}
