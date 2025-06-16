using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Model
{
    public short Code { get; set; }

    public short CodeCompany { get; set; }

    public string? Model1 { get; set; }

    public short? DriveType { get; set; }

    public short? TypeVehicles { get; set; }

    public bool? IsDelete { get; set; }

    public virtual ICollection<Car> Cars { get; } = new List<Car>();

    public virtual Company CodeCompanyNavigation { get; set; } = null!;

    public virtual DriveType? DriveTypeNavigation { get; set; }

    public virtual TypeVehicle? TypeVehiclesNavigation { get; set; }
}
