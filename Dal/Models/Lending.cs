using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Lending
{
    public short Code { get; set; }

    public int IdUser { get; set; }

    public DateTime? Date { get; set; }

    public short? Hour { get; set; }

    public short? CodeCar { get; set; }

    public DateTime? ReturnDate { get; set; }

    public short? ReturnHour { get; set; }

    public bool? ReturnCar { get; set; }

    public virtual Car? CodeCarNavigation { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Restitution> Restitutions { get; } = new List<Restitution>();
}
