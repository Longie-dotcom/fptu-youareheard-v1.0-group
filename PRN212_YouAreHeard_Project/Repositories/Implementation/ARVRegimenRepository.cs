using BussinessObjects;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class ArvregimanRepository : IArvregimanRepository
    {
        public List<Arvregiman> GetAll()
        {
            return ArvregimanDAO.GetAll();
        }

        public Arvregiman? GetById(int id)
        {
            return ArvregimanDAO.GetById(id);
        }
    }
}
