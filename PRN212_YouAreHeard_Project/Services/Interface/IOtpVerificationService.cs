using BussinessObjects;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IOtpverificationService
    {
        void GenerateAndAutoVerifyOtpWithContext(
            string email, DataAccessLayer.YouAreHeardContext context);
    }
}
