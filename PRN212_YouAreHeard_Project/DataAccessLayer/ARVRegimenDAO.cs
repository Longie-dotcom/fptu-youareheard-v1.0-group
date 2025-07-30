using BussinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class ArvregimanDAO
    {
        public static List<Arvregiman> GetAll()
        {
            using var context = new YouAreHeardContext();
            return context.Arvregimen.ToList();
        }

        public static Arvregiman? GetById(int id)
        {
            using var context = new YouAreHeardContext();
            return context.Arvregimen.Find(id);
        }
    }
}
