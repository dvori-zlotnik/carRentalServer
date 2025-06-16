using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converts
{
    internal class TypeDriveConvert
    {
        public static Dto.DriveType to_dto(Models.DriveType drive)
        {
            Dto.DriveType d= new Dto.DriveType();
            d.Code = drive.Code;
            d.Description = drive.Description;
            return d;
        }

        public static Models.DriveType to_dal(Dto.DriveType drive) 
        {
            Models.DriveType d= new Models.DriveType();
            d.Description = drive.Description;
            return d;
        }
        public static List<Dto.DriveType> to_dto_list(List<Models.DriveType> drive) 
        {
            List<Dto.DriveType> driveTypes = new List<Dto.DriveType>();
            foreach (Models.DriveType driveType in drive)
                driveTypes.Add(to_dto(driveType));
            return driveTypes;
        }
    }
}
