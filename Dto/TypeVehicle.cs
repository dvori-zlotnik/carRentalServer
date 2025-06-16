using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class TypeVehicle
    {
        public short Code { get; set; }
        public string Description { get; set; } = null!;

        public string Size { get; set; } = null!;
    }
}
