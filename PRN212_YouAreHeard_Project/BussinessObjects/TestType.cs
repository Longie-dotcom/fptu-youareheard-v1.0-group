using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class TestType
{
    public int TestTypeId { get; set; }

    public string? TestTypeName { get; set; }

    public virtual ICollection<LabResult> LabResults { get; set; } = new List<LabResult>();
}
