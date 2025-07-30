using BussinessObjects;

namespace Services.Interface
{
    public interface IDoctorProfileService
    {
        List<DoctorProfile> GetAll();
        DoctorProfile? GetById(int userId);
        void Add(DoctorProfile doctor);
        void Update(DoctorProfile doctor);
        void Delete(int userId);
        void AddDoctorProfileWithUser(DoctorProfile doctor, User user);
    }
}