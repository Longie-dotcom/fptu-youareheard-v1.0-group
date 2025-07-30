using System;
using System.Collections.Generic;
using System.Linq;
using BussinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class TestTypeDAO
    {
        public static List<TestType> GetAllTestTypes()
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    return context.TestTypes.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static TestType GetTestTypeById(int testTypeId)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    return context.TestTypes
                        .FirstOrDefault(tt => tt.TestTypeId == testTypeId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddTestType(TestType testType)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    context.TestTypes.Add(testType);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateTestType(TestType testType)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var existing = context.TestTypes.Find(testType.TestTypeId);
                    if (existing != null)
                    {
                        existing.TestTypeName = testType.TestTypeName;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteTestType(int id)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var testType = context.TestTypes.Find(id);
                    if (testType != null)
                    {
                        context.TestTypes.Remove(testType);
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