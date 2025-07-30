using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace DataAccessLayer
{
    public class HIVStatusDAO
    {
        public static List<Hivstatus> GetAll()
        {
            try
            {
                using var context = new YouAreHeardContext();
                return context.Hivstatuses.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Hivstatus GetById(int id)
        {
            try
            {
                using var context = new YouAreHeardContext();
                return context.Hivstatuses.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Add(Hivstatus status)
        {
            try
            {
                using var context = new YouAreHeardContext();
                context.Hivstatuses.Add(status);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Update(Hivstatus status)
        {
            try
            {
                using var context = new YouAreHeardContext();
                var existing = context.Hivstatuses.Find(status.HivstatusId);
                if (existing != null)
                {
                    existing.HivstatusName = status.HivstatusName;
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
                var status = context.Hivstatuses.Find(id);
                if (status != null)
                {
                    context.Hivstatuses.Remove(status);
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
