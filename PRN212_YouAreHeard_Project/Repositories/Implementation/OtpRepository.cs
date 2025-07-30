using BussinessObjects;
using DataAccessLayer;
using Repositories.Interface;
using System.Collections.Generic;

namespace Repositories.Implementation
{
    public class OtpverificationRepository : IOtpverificationRepository
    {
        public Otpverification GetByEmailAndOtp(string email, string otp)
        {
            return OtpverificationDAO.GetOtpByEmailAndOtp(email, otp);
        }

        public List<Otpverification> GetAll()
        {
            return OtpverificationDAO.GetAllOtps();
        }

        public Otpverification? GetById(int id)
        {
            return OtpverificationDAO.GetOtpById(id);
        }

        public void Add(Otpverification otp)
        {
            OtpverificationDAO.AddOtp(otp);
        }

        public void Update(Otpverification otp)
        {
            OtpverificationDAO.UpdateOtp(otp);
        }

        public void Delete(int id)
        {
            OtpverificationDAO.DeleteOtp(id);
        }

        public void AddOtpWithContext(Otpverification otp, DataAccessLayer.YouAreHeardContext context)
        {
            OtpverificationDAO.AddOtpWithContext(otp, context);
        }
    }
}
