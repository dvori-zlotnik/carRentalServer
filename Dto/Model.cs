namespace Dto
{
    public class Model
    {
        public short Code { get; set; }
        public short CodeCompany { get; set; }

        public short? DriveType_code { get; set; }

        public short? TypeVehicles_code { get; set; }
        public string? Model_name { get; set; }

        public string? DriveType { get; set; }

        public string? TypeVehicles { get; set; }

        public string Company { get; set; } = null!;

        public string Image_company { get; set; } = null!;
        public string? size { get; set; }

    }
}