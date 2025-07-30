using BussinessObjects;
using DataAccessLayer;
using Repository.Interface;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Repository.Implementation
{
    public class HIVStatusRepository : IHIVStatusRepository
    {
        public List<Hivstatus> GetAll()
        {
            return HIVStatusDAO.GetAll();
        }

        public Hivstatus GetById(int id)
        {
            return HIVStatusDAO.GetById(id);
        }

        public void Add(Hivstatus status)
        {
            HIVStatusDAO.Add(status);
        }

        public void Update(Hivstatus status)
        {
            HIVStatusDAO.Update(status);
        }

        public void Delete(int id)
        {
            HIVStatusDAO.Delete(id);
        }
    }
}
