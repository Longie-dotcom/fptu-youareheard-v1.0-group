using BussinessObjects;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class ArvregimanService : IArvregimanService
    {
        private readonly IArvregimanRepository _arvregimanRepository;

        public ArvregimanService()
        {
            _arvregimanRepository = new ArvregimanRepository();
        }

        public List<Arvregiman> GetAll()
        {
            return _arvregimanRepository.GetAll();
        }

        public Arvregiman? GetById(int id)
        {
            return _arvregimanRepository.GetById(id);
        }
    }
}
