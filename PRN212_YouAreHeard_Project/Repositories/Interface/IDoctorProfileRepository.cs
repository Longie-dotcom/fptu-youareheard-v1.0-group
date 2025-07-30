using BussinessObjects;

namespace Repositories.Interface
{
    public interface IDoctorProfileRepository
    {
        List<DoctorProfile> GetAll();
        DoctorProfile? GetById(int userId);
        void Add(DoctorProfile doctor);
        void Update(DoctorProfile doctor);
        void Delete(int userId);
        void AddDoctorWithContext(DoctorProfile doctor, DataAccessLayer.YouAreHeardContext context);
    }
}
