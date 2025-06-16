using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Cities:IDal.IDal<Dto.City>
    {
        private readonly CarRentalContext _db;
        public Cities(CarRentalContext db)
        {
            _db = db;
        }

        public async Task<List<Dto.City>> SelectAllAsync()
        {
            try
            {
                var cities = await _db.Cities.Where(c => c.IsDelete != true).ToListAsync();
                return Dal.converts.CltyConvert.to_list_dto(cities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> AddAsync(Dto.City city)
        {
            _db.Cities.Add(converts.CltyConvert.to_dal(city));
            int x = await _db.SaveChangesAsync();
            return x;
        }
        public async Task<int> DeleteAsync(int code)
        {
            var city = await _db.Cities.FirstOrDefaultAsync(x => x.Code == code);
            if(city != null) 
            {
                city.IsDelete = true;
                int x= await _db.SaveChangesAsync();
                return x;
            }
            return -1;
        }
    }
}
