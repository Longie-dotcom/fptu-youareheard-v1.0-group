using System;
using System.Collections.Generic;
using System.Linq;
using BussinessObjects;

namespace DataAccessLayer
{
    public class TestStageDAO
    {
        public static List<TestStage> GetAllTestStages()
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    return context.TestStages.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static TestStage GetById(int id)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    return context.TestStages.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddTestStage(TestStage stage)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    context.TestStages.Add(stage);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateTestStage(TestStage stage)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var existing = context.TestStages.Find(stage.TestStageId);
                    if (existing != null)
                    {
                        existing.TestStageName = stage.TestStageName;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteTestStage(int id)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var stage = context.TestStages.Find(id);
                    if (stage != null)
                    {
                        context.TestStages.Remove(stage);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
