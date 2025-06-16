using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Company
{
    public short Code { get; set; }

    public string Name { get; set; } = null!;

    public string? Image { get; set; }

    public bool? IsDelete { get; set; }

    public virtual ICollection<Model> Models { get; } = new List<Model>();
}
