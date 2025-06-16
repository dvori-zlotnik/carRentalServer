using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class DriveTypes
    {
        IDal.IDal<Dto.DriveType> idal;
        public DriveTypes(IDal.IDal<Dto.DriveType> dal)
        {
            idal = dal;
        }
        public async Task<List<Dto.DriveType>> SelectAllAsync()
        {
            var drivetype = await idal.SelectAllAsync();
            return drivetype;
        }

        public async  Task<int> AddAsync(Dto.DriveType driveType)
        {
            int x = await idal.AddAsync(driveType);
            return x;
        }
        public async Task<int> DeleteAsync(int code)
        {
            return await idal.DeleteAsync(code);
        }
    }
}
