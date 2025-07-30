using BussinessObjects;
using Repository.Implementation;
using Repository.Interface;
using Services.Interface;
using System.Collections.Generic;

namespace Services.Implementation
{
    public class LabResultService : ILabResultService
    {
        private readonly ILabResultRepository _labResultRepository;

        public LabResultService()
        {
            _labResultRepository = new LabResultRepository();
        }

        public List<LabResult> GetAll()
        {
            return _labResultRepository.GetAll();
        }

        public LabResult GetById(int id)
        {
            return _labResultRepository.GetById(id);
        }

        public LabResult Add(LabResult labResult)
        {
            return _labResultRepository.Add(labResult);
        }

        public void Update(LabResult labResult)
        {
            _labResultRepository.Update(labResult);
        }

        public void Delete(int id)
        {
            _labResultRepository.Delete(id);
        }
    }
}
