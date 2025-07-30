using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class SupportRequest
{
    public int RequestId { get; set; }

    public int? UserId { get; set; }

    public int SubjectId { get; set; }

    public int SupportRequestStatusId { get; set; }

    public int? RepliedBy { get; set; }

    public string Message { get; set; } = null!;

    public bool? IsAnonymous { get; set; }

    public string? Reply { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? RepliedDate { get; set; }

    public virtual User? RepliedByNavigation { get; set; }

    public virtual SupportSubject Subject { get; set; } = null!;

    public virtual SupportRequestStatus SupportRequestStatus { get; set; } = null!;

    public virtual User? User { get; set; }
}
