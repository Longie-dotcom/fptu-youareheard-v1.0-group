using BussinessObjects;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Repository.Interface
{
    public interface IHIVStatusRepository
    {
        List<Hivstatus> GetAll();
        Hivstatus GetById(int id);
        void Add(Hivstatus status);
        void Update(Hivstatus status);
        void Delete(int id);
    }
}
