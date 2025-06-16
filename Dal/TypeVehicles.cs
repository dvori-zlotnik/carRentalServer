using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class TypeVehicles:IDal.IDal<Dto.TypeVehicle>
    {
        private readonly CarRentalContext _db;
        public TypeVehicles(CarRentalContext db) { _db = db; }
        public async Task<List<Dto.TypeVehicle>> SelectAllAsync()
        {
            try
            {
                var typeVehicles = await _db.TypeVehicles.Where(c => c.IsDelete != true).ToListAsync();
                return converts.TypeVehicle.to_dto_list( typeVehicles);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddAsync(Dto.TypeVehicle typeVehicle)
        {
            _db.TypeVehicles.AddAsync(converts.TypeVehicle.to_dal(typeVehicle));
            int x = await _db.SaveChangesAsync();
            return x;
        }
        public async Task<int> DeleteAsync(int code)
        {
            var type = _db.TypeVehicles.FirstOrDefault(x => x.Code == code);
            Console.WriteLine(type);
            if (type != null)
            {
                type.IsDelete = true;
                int x = await _db.SaveChangesAsync();
                return x;
            }
            return -10000;
        }
    }
}
