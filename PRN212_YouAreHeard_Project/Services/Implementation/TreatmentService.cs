using BussinessObjects;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class TreatmentPlanService : ITreatmentPlanService
    {
        private readonly ITreatmentPlanRepository _treatmentPlanRepository;

        public TreatmentPlanService()
        {
            _treatmentPlanRepository = new TreatmentPlanRepository();
        }

        public TreatmentPlan Add(TreatmentPlan treatmentPlan)
        {
            return _treatmentPlanRepository.Add(treatmentPlan);
        }

        public TreatmentPlan? GetLatestByPatientId(int patientId)
        {
            return _treatmentPlanRepository.GetLatestByPatientId(patientId);
        }
    }
}
