using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class Otpverification
{
    public int Otpid { get; set; }

    public string? Otp { get; set; }

    public string? Email { get; set; }

    public DateTime? ExpiredDate { get; set; }

    public bool? IsVerified { get; set; }

    public virtual User? EmailNavigation { get; set; }
}
