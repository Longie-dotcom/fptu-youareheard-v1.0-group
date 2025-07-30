using BussinessObjects;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Services.Interface
{
    public interface IHIVStatusService
    {
        List<Hivstatus> GetAll();
        Hivstatus GetById(int id);
        void Add(Hivstatus status);
        void Update(Hivstatus status);
        void Delete(int id);
    }
}
