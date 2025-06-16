using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class TypeVehicles
    {
        IDal.IDal<Dto.TypeVehicle> idal;
        public TypeVehicles(IDal.IDal<Dto.TypeVehicle> dal)
        {
            idal = dal;
        }
        public async Task<List<Dto.TypeVehicle>> SelectAllAsync()
        {
            var typeVehicles = await idal.SelectAllAsync();
            return typeVehicles;
        }

        public async Task<int> AddAsync(Dto.TypeVehicle typeVehicle)
        {
            int x = await idal.AddAsync(typeVehicle);
            return x;
        }

        public async Task<int> DeleteAsync(int code)
        {
            return await idal.DeleteAsync(code);
        }
    }
}
