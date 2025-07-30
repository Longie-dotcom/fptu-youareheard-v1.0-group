using BussinessObjects;
using DataAccessLayer;
using Helper;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class DoctorProfileService : IDoctorProfileService
    {
        private readonly IDoctorProfileRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IOtpverificationService _otpVerificationService;

        public DoctorProfileService()
        {
            _repository = new DoctorProfileRepository();
            _userRepository = new UserRepository();
            _otpVerificationService = new OtpverificationService();
        }

        public List<DoctorProfile> GetAll()
        {
            return _repository.GetAll();
        }

        public DoctorProfile? GetById(int userId)
        {
            return _repository.GetById(userId);
        }

        public void Add(DoctorProfile doctor)
        {

            _repository.Add(doctor);
        }

        public void Update(DoctorProfile doctor)
        {
            _repository.Update(doctor);
        }

        public void Delete(int userId)
        {
            _repository.Delete(userId);
        }

        public void AddDoctorProfileWithUser(DoctorProfile doctor, User user)
        {
            using (var context = new DataAccessLayer.YouAreHeardContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    int userId = _userRepository.AddUserWithContext(user, context);

                    doctor.UserId = userId;
                    _repository.AddDoctorWithContext(doctor, context);

                    _otpVerificationService.GenerateAndAutoVerifyOtpWithContext(user.Email, context);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}