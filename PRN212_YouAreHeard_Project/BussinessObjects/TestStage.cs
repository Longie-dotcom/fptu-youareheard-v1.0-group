using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class TestStage
{
    public int TestStageId { get; set; }

    public string? TestStageName { get; set; }

    public virtual ICollection<LabResult> LabResults { get; set; } = new List<LabResult>();
}
