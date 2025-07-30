using BussinessObjects;

namespace Repositories.Interface
{
    public interface IArvregimanRepository
    {
        List<Arvregiman> GetAll();
        Arvregiman? GetById(int id);
    }
}
