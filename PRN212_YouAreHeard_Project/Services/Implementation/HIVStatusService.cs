using BussinessObjects;
using Repositories.Interface;
using Repositories.Implementation;
using Services.Interface;
using System.Collections.Generic;
using Repository.Implementation;
using Repository.Interface;
using System.Net.NetworkInformation;

namespace Services.Implementation
{
    public class HIVStatusService : IHIVStatusService
    {
        private readonly IHIVStatusRepository _hivStatusRepository;

        public HIVStatusService()
        {
            _hivStatusRepository = new HIVStatusRepository();
        }

        public List<Hivstatus> GetAll()
        {
            return _hivStatusRepository.GetAll();
        }

        public Hivstatus GetById(int id)
        {
            return _hivStatusRepository.GetById(id);
        }

        public void Add(Hivstatus status)
        {
            _hivStatusRepository.Add(status);
        }

        public void Update(Hivstatus status)
        {
            _hivStatusRepository.Update(status);
        }

        public void Delete(int id)
        {
            _hivStatusRepository.Delete(id);
        }
    }
}
