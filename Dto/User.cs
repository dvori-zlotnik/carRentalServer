using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class User
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Password { get; set; }

        public string? NumCreditCard { get; set; }

        public string? Validity { get; set; }

        public string? Cvv { get; set; }

        public bool? IsManager { get; set; }
        public ICollection<Lending> Lendings { get; set; } = new List<Lending>();
    }
}
