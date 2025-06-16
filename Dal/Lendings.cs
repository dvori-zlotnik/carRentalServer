using Dal.Models;
using IDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Lendings:IDal.IDal<Dto.Lending>
    {
        private readonly CarRentalContext _db;
        private readonly ICar _car;
        public Lendings(CarRentalContext db,ICar car)
        {
            _db = db;
            _car = car;
        }
        public async Task<int> AddAsync(Dto.Lending lending )
        {
            try
            {
                Lending lending1 = Convert.LendingConvert.ToLending(lending);
                _db.Lendings.Add(lending1);
                await _car.Update_ava_Async(lending1.CodeCar, false);
                await _db.SaveChangesAsync();
                return lending1.Code;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Dto.Lending>> SelectAllAsync()
        {
                var q1 = await _db.Lendings.Include(l => l.IdUserNavigation).Include(l=>l.CodeCarNavigation)
                .ToListAsync();
            try
            {

                return Convert.LendingConvert.ToListLendingDto(q1);

            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<int> DeleteAsync(int code)
        {
            var c = await _db.Lendings.FirstOrDefaultAsync(c => c.Code == code);
            if (c == null)
                return -1;
            else
            {
                _db.Lendings.Remove(c);

                int x = await _db.SaveChangesAsync();
                return x;
            }
        }
        public async Task<int> UpdateReturnAsync(int code)
        {
            var lNew = await _db.Lendings.Include(l=>l.CodeCarNavigation).FirstOrDefaultAsync(c => c.Code == code);
            if (lNew == null)
                return -1;

            else
            {
                lNew.ReturnCar = true; 
              if( lNew.CodeCarNavigation !=null )
                {
                  await  _car.Update_ava_Async(lNew.CodeCar, true);
                }
                int x = await _db.SaveChangesAsync();
                return x;
            }

        }
    }
}
