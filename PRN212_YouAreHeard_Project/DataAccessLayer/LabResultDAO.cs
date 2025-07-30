using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class LabResultDAO
    {
        public static List<LabResult> GetAll()
        {
            try
            {
                using var context = new YouAreHeardContext();
                return context.LabResults
                    .Include(l => l.TestStage)
                    .Include(l => l.TestType)
                    .Include(l => l.TestMetricValues)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static LabResult GetById(int id)
        {
            try
            {
                using var context = new YouAreHeardContext();
                return context.LabResults
                    .Include(l => l.TestMetricValues)
                    .FirstOrDefault(l => l.LabResultId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static LabResult Add(LabResult result)
        {
            try
            {
                using var context = new YouAreHeardContext();
                context.LabResults.Add(result);
                context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Update(LabResult result)
        {
            try
            {
                using var context = new YouAreHeardContext();
                context.LabResults.Update(result);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Delete(int id)
        {
            try
            {
                using var context = new YouAreHeardContext();
                var lab = context.LabResults.Find(id);
                if (lab != null)
                {
                    context.LabResults.Remove(lab);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
