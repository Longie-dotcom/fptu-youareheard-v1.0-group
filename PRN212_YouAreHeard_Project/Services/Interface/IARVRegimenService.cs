using BussinessObjects;

namespace Services.Interface
{
    public interface IArvregimanService
    {
        List<Arvregiman> GetAll();
        Arvregiman? GetById(int id);
    }
}
