using BussinessObjects;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class DoctorProfileRepository : IDoctorProfileRepository
    {
        public List<DoctorProfile> GetAll()
        {
            return DoctorProfileDAO.GetAllDoctors();
        }

        public DoctorProfile? GetById(int userId)
        {
            return DoctorProfileDAO.GetDoctorById(userId);
        }

        public void Add(DoctorProfile doctor)
        {
            DoctorProfileDAO.AddDoctor(doctor);
        }

        public void Update(DoctorProfile doctor)
        {
            DoctorProfileDAO.UpdateDoctor(doctor);
        }

        public void Delete(int userId)
        {
            DoctorProfileDAO.DeleteDoctor(userId);
        }

        public void AddDoctorWithContext(DoctorProfile doctor, DataAccessLayer.YouAreHeardContext context) 
        { 
            DoctorProfileDAO.AddDoctorWithContext(doctor, context);    
        }
    }
}
