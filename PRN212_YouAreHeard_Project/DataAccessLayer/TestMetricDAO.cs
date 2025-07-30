using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class TestMetricDAO
    {
        public static List<TestMetric> GetAll()
        {
            try
            {
                using var context = new YouAreHeardContext();
                return context.TestMetrics.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static TestMetric GetById(int id)
        {
            try
            {
                using var context = new YouAreHeardContext();
                return context.TestMetrics.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<TestMetric> GetTestMetricsByTypeId(int testTypeId)
        {
            try
            {
                using var context = new YouAreHeardContext();
                return context.TestMetricCombinations
                    .Where(c => c.TestTypeId == testTypeId)
                    .Include(c => c.TestMetric)
                    .Select(c => c.TestMetric)
                    .Where(m => m != null)
                    .ToList()!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching test metrics: " + ex.Message);
            }
        }

        public static void Add(TestMetric metric)
        {
            try
            {
                using var context = new YouAreHeardContext();
                context.TestMetrics.Add(metric);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Update(TestMetric metric)
        {
            try
            {
                using var context = new YouAreHeardContext();
                var existing = context.TestMetrics.Find(metric.TestMetricId);
                if (existing != null)
                {
                    existing.TestMetricName = metric.TestMetricName;
                    existing.TestMetricTypeId = metric.TestMetricTypeId;
                    context.SaveChanges();
                }
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
                var metric = context.TestMetrics.Find(id);
                if (metric != null)
                {
                    context.TestMetrics.Remove(metric);
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