using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class DriveType
{
    public short Code { get; set; }

    public string Description { get; set; } = null!;

    public bool? IsDelete { get; set; }

    public virtual ICollection<Model> Models { get; } = new List<Model>();
}
