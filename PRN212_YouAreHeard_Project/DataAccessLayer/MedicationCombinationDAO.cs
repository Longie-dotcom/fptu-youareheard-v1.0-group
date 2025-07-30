using BussinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class MedicationCombinationDAO
    {
        public static List<MedicationCombination> GetByRegimenId(int regimenId)
        {
            using var context = new YouAreHeardContext();
            return context.MedicationCombinations
                          .Where(mc => mc.RegimenId == regimenId)
                          .Include(mc => mc.Medication)
                          .ToList();
        }
    }
}
