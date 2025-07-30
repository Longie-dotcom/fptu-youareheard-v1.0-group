using BussinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class PillRemindTimeDAO
    {
        public static List<PillRemindTime> GetAllByTreatmentPlan(int treatmentPlanId)
        {
            using var context = new YouAreHeardContext();
            return context.PillRemindTimes
                          .Where(p => p.TreatmentPlanId == treatmentPlanId)
                          .Include(p => p.Medication)
                          .ToList();
        }

        public static void AddRange(List<PillRemindTime> times)
        {
            using var context = new YouAreHeardContext();
            try
            {
                foreach (var time in times)
                {
                    // Ensure you're only setting FK IDs, not full navigation objects
                    context.PillRemindTimes.Add(new PillRemindTime
                    {
                        MedicationId = time.MedicationId,
                        TreatmentPlanId = time.TreatmentPlanId,
                        Time = time.Time,
                        DrinkDosage = time.DrinkDosage,
                        Notes = time.Notes
                    });
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add PillRemindTimes: " + ex.Message);
            }
        }
    }
}
