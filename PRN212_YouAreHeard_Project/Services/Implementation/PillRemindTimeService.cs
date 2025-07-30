using BussinessObjects;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class PillRemindTimeService : IPillRemindTimeService
    {
        private readonly IPillRemindTimeRepository _pillRemindTimeRepository;

        public PillRemindTimeService()
        {
            _pillRemindTimeRepository = new PillRemindTimeRepository();
        }

        public void AddRange(List<PillRemindTime> reminders)
        {
            _pillRemindTimeRepository.AddRange(reminders);
        }

        public List<PillRemindTime> GetByTreatmentPlanId(int treatmentPlanId)
        {
            return _pillRemindTimeRepository.GetAllByTreatmentPlan(treatmentPlanId);
        }
    }
}
