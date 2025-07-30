using System;
using System.Collections.Generic;

namespace BussinessObjects;

public partial class Blog
{
    public int BlogId { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Details { get; set; } = null!;

    public string? Image { get; set; }

    public DateTime Date { get; set; }

    public virtual User? User { get; set; }
}
