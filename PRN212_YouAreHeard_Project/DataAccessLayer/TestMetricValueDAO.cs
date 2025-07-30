using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class TestMetricValueDAO
    {
        public static List<TestMetricValue> GetByLabResultId(int labResultId)
        {
            try
            {
                using var context = new YouAreHeardContext();
                return context.TestMetricValues
                    .Include(t => t.TestMetric)
                    .Where(t => t.LabResultId == labResultId)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddRange(List<TestMetricValue> values)
        {
            try
            {
                using var context = new YouAreHeardContext();
                context.TestMetricValues.AddRange(values);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
