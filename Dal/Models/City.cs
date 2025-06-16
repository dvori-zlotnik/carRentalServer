using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class City
{
    public short Code { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsDelete { get; set; }

    public virtual ICollection<Car> Cars { get; } = new List<Car>();
}
