using BussinessObjects;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class TreatmentPlanRepository : ITreatmentPlanRepository
    {
        public List<TreatmentPlan> GetAll()
        {
            return TreatmentPlanDAO.GetAll();
        }

        public TreatmentPlan? GetById(int id)
        {
            return TreatmentPlanDAO.GetById(id);
        }

        public TreatmentPlan Add(TreatmentPlan plan)
        {
            return TreatmentPlanDAO.Add(plan);
        }

        public void Update(TreatmentPlan plan)
        {
            TreatmentPlanDAO.Update(plan);
        }

        public void Delete(int id)
        {
            TreatmentPlanDAO.Delete(id);
        }

        public TreatmentPlan? GetLatestByPatientId(int patientId)
        {
            return TreatmentPlanDAO.GetLatestByPatientId(patientId);
        }
    }
}
