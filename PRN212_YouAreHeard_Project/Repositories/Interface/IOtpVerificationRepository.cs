using BussinessObjects;
using System.Collections.Generic;

namespace Repositories.Interface
{
    public interface IOtpverificationRepository
    {
        List<Otpverification> GetAll();
        Otpverification? GetById(int id);
        Otpverification GetByEmailAndOtp(string email, string otp);
        void Add(Otpverification otp);
        void Update(Otpverification otp);
        void Delete(int id);
        void AddOtpWithContext(Otpverification otp, DataAccessLayer.YouAreHeardContext context);
    }
}
