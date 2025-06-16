using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class Lending
    {
        public short? Code { get; set; }

        public int IdUser { get; set; }

        public DateTime? Date { get; set; }

        public short? Hour { get; set; }

        public string? userName { get; set; }

        public short? code_car { get; set; }
        public DateTime? ReturnDate { get; set; }

        public short? ReturnHour { get; set; }

        public bool? ReturnCar { get; set; }
    }
}

