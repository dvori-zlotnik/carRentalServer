using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DriveTypes:IDal.IDal<Dto.DriveType>
    {
        private readonly CarRentalContext _db;
        public DriveTypes(CarRentalContext db) { _db = db; }
        public async Task<List<Dto.DriveType>> SelectAllAsync()
        {
            try
            {
                var drive = await _db.DriveTypes.Where(d => d.IsDelete != true).ToListAsync();
                return converts.TypeDriveConvert.to_dto_list(drive);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddAsync(Dto.DriveType driveType)
        {
            _db.DriveTypes.AddAsync(converts.TypeDriveConvert.to_dal(driveType));
            int x = await _db.SaveChangesAsync();
            return x;
        }
        public async Task<int> DeleteAsync(int code)
        {
            var drive = await _db.DriveTypes.FirstOrDefaultAsync(x => x.Code == code);
            if (drive != null)
            {
                drive.IsDelete = true;
                int x = await _db.SaveChangesAsync();
                return x;
            }
            return -1;
        }
    }
}
