using System;
using System.Collections.Generic;
using Dal.Models;

namespace Dal.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public string? NumCreditCard { get; set; }

    public string? Validity { get; set; }

    public string? Cvv { get; set; }

    public bool? IsManager { get; set; }

    public bool? IsDelete { get; set; }

    public virtual ICollection<Lending> Lendings { get; } = new List<Lending>();
}
