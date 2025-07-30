using BussinessObjects;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IPillRemindTimeService
    {
        void AddRange(List<PillRemindTime> reminders);
        List<PillRemindTime> GetByTreatmentPlanId(int treatmentPlanId);
    }
}
