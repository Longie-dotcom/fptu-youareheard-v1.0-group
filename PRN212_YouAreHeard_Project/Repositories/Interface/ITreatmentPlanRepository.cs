using BussinessObjects;

namespace Repositories.Interface
{
    public interface ITreatmentPlanRepository
    {
        List<TreatmentPlan> GetAll();
        TreatmentPlan? GetById(int id);
        TreatmentPlan Add(TreatmentPlan plan);
        void Update(TreatmentPlan plan);
        void Delete(int id);
        TreatmentPlan? GetLatestByPatientId(int patientId);
    }
}
