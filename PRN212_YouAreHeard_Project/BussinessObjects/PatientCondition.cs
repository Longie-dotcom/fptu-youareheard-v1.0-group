using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class PatientCondition
{
    public int? ConditionId { get; set; }

    public int? UserId { get; set; }

    public virtual Condition? Condition { get; set; }

    public virtual PatientProfile? User { get; set; }
}
