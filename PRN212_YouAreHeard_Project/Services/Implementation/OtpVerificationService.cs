using BussinessObjects;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;
using System.Collections.Generic;

namespace Services.Implementation
{
    public class OtpverificationService : IOtpverificationService
    {
        private readonly IOtpverificationRepository _otpverificationRepository;

        public OtpverificationService()
        {
            _otpverificationRepository = new OtpverificationRepository();
        }

        public void GenerateAndAutoVerifyOtpWithContext(
            string email, DataAccessLayer.YouAreHeardContext context)
        {
            var otp = GenerateOTP();
            var otpverification = new Otpverification
            {
                Email = email,
                Otp = otp,
                IsVerified = true,
                ExpiredDate = DateTime.Now.AddMinutes(5)
            };

            _otpverificationRepository.AddOtpWithContext(otpverification, context);
        }

        private string GenerateOTP(int length = 6)
        {
            var random = new Random();
            return string.Concat(Enumerable.Range(0, length).Select(_ => random.Next(0, 10).ToString()));
        }

    }
}
