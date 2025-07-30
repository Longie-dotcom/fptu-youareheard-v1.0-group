using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class SupportSubject
{
    public int SubjectId { get; set; }

    public string? SubjectName { get; set; }

    public virtual ICollection<SupportRequest> SupportRequests { get; set; } = new List<SupportRequest>();
}
