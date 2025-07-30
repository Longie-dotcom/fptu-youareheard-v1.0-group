using BussinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class TreatmentPlanDAO
    {
        public static List<TreatmentPlan> GetAll()
        {
            using var context = new YouAreHeardContext();
            return context.TreatmentPlans
                          .Include(tp => tp.Regimen)
                          .Include(tp => tp.Doctor)
                          .Include(tp => tp.Patient)
                          .ToList();
        }

        public static TreatmentPlan? GetById(int id)
        {
            using var context = new YouAreHeardContext();
            return context.TreatmentPlans
                          .Include(tp => tp.Regimen)
                          .FirstOrDefault(tp => tp.TreatmentPlanId == id);
        }

        public static TreatmentPlan Add(TreatmentPlan plan)
        {
            try
            {
                using var context = new YouAreHeardContext();
                context.TreatmentPlans.Add(plan);
                context.SaveChanges();
                return plan;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add TreatmentPlan: " + ex.Message);
            }
        }

        public static void Update(TreatmentPlan plan)
        {
            using var context = new YouAreHeardContext();
            try
            {
                context.TreatmentPlans.Update(plan);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update TreatmentPlan: " + ex.Message);
            }
        }

        public static void Delete(int id)
        {
            using var context = new YouAreHeardContext();
            try
            {
                var plan = context.TreatmentPlans.Find(id);
                if (plan != null)
                {
                    context.TreatmentPlans.Remove(plan);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete TreatmentPlan: " + ex.Message);
            }
        }

        public static TreatmentPlan? GetLatestByPatientId(int patientId)
        {
            using var context = new YouAreHeardContext();
            return context.TreatmentPlans
                          .Include(tp => tp.Regimen)
                          .Where(tp => tp.PatientId == patientId)
                          .OrderByDescending(tp => tp.Date)     // newest first
                          .FirstOrDefault();
        }
    }
}
