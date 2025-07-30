using BussinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class MedicationDAO
    {
        public static List<Medication> GetAll()
        {
            using var context = new YouAreHeardContext();
            return context.Medications.ToList();
        }

        public static Medication? GetById(int id)
        {
            using var context = new YouAreHeardContext();
            return context.Medications.Find(id);
        }
    }
}
