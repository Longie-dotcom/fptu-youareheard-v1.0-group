using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class SupportRequestStatus
{
    public int SupportRequestStatusId { get; set; }

    public string? SupportRequestStatusName { get; set; }

    public virtual ICollection<SupportRequest> SupportRequests { get; set; } = new List<SupportRequest>();
}
