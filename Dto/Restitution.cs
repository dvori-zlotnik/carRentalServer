using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class Restitution
    {
        public short Code { get; set; }

        public short? CodeLending { get; set; }

        public DateTime? Date { get; set; }

        public short? Hour { get; set; }

        public short? Balance { get; set; }

        public int? TotalPayable { get; set; }

        public bool? Paid { get; set; }

        public virtual Lending? CodeLendingNavigation { get; set; }
    }
}
