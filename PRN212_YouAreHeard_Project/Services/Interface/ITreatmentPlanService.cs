using BussinessObjects;

namespace Services.Interface
{
    public interface ITreatmentPlanService
    {
        TreatmentPlan Add(TreatmentPlan treatmentPlan);
        TreatmentPlan? GetLatestByPatientId(int patientId);
    }
}
