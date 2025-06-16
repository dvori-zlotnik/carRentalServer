using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class Car
    {
        public short Code { get; set; }

        public short? City_code { get; set; }

        public short? CodeModel { get; set; }

        public string? LicensePlate { get; set; }

        public short? NumberOfSeats { get; set; }

        public bool? Gear { get; set; }

        public string? Image { get; set; }

        public short? Year { get; set; }

        public bool? Available { get; set; }

        public string? City { get; set; }

        public short? PricePerHour { get; set; }

        public short? ConsumptionPerKm { get; set; }

        public short? BalanceInLiters { get; set; }

        public string? Model_name { get; set; }
        public short? DriveType_code { get; set; }
        public string? DriveType { get; set; }
        public short? TypeVehicles_code { get; set; }

        public string? TypeVehicles { get; set; }
        public string? size { get; set; }


        public string? Company { get; set; } = null!;

        public string? Image_company { get; set; } = null!;


    }
}
