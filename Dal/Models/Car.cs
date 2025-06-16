using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Car
{
    public short Code { get; set; }

    public string? LicensePlate { get; set; }

    public short? NumberOfSeats { get; set; }

    public bool? Gear { get; set; }

    public string? Image { get; set; }

    public short? Year { get; set; }

    public bool? Available { get; set; }

    public short? CodeModel { get; set; }

    public short? City { get; set; }

    public short? PricePerHour { get; set; }

    public short? ConsumptionPerKm { get; set; }

    public short? BalanceInLiters { get; set; }

    public bool? IsDelete { get; set; }

    public virtual City? CityNavigation { get; set; }

    public virtual Model? CodeModelNavigation { get; set; }

    public virtual ICollection<Lending> Lendings { get; } = new List<Lending>();
}
