using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Cars:IDal.ICar
    {
        private readonly CarRentalContext _db;
        public Cars(CarRentalContext db) {  _db = db; }
        public async Task<List<Dto.Car>> SelectAllAsync()
        {
            try
            {
                {
                    var cars = await _db.Cars.Include(c => c.CityNavigation).Include(c => c.CodeModelNavigation).ThenInclude(m => m.TypeVehiclesNavigation).Where(c => c.IsDelete != true).ToListAsync();
                    return await converts.CarsConvert.to_list_dto(cars);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<Dto.Car>? SelectOne(int code)
        {
            List<Models.Car> cars = _db.Cars.Include(c => c.CityNavigation)
                .Include(c => c.CodeModelNavigation).ThenInclude(m=>m.TypeVehiclesNavigation)
                .Include(c=> c.CodeModelNavigation).ThenInclude(m=>m.DriveTypeNavigation).ToList();
            var car = cars.FirstOrDefault(c => c.Code == code);
            if (car == null)
                return null;
             return await converts.CarsConvert.To_dto(car);
        }
        public async Task<int> Update_ava_Async(short? code,bool available)
        {
            var car = await _db.Cars.SingleOrDefaultAsync(c => c.Code == code);
            if (car == null) return -1;
            car.Available= available;
            int x = await _db.SaveChangesAsync();
             return x;
        }

        public async Task<int> Update_balance_Async(int code, short balance)
        {
            var car = await _db.Cars.SingleOrDefaultAsync(c => c.Code == code);
            if (car == null) return -1;
            car.BalanceInLiters = balance;
            int x = await _db.SaveChangesAsync();
            return x;
        }
        public async Task<int> Update_img_Async(int code, string img)
        {
            var car = await _db.Cars.SingleOrDefaultAsync(c => c.Code == code);
            if(car == null) return -1;
            car.Image = img;
            int x = await _db.SaveChangesAsync();
            return x;
        }

        public async Task<int> DeleteAsync(int code)
        {
            var car = await _db.Cars.FirstOrDefaultAsync(c => c.Code == code);
            if(car != null) 
            {
                car.IsDelete = true;
                int x = await _db.SaveChangesAsync();
                return x;
            }
            return -1;
        }

        public async Task<int> AddAsync(Dto.Car car)
        {
            try
            {
                _db.Add(converts.CarsConvert.to_dal(car));
                int x = await _db.SaveChangesAsync();
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
