using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Users:IDal.IDal<Dto.User>
    {
        private readonly CarRentalContext _db;
        public Users(CarRentalContext db)
        {
            _db = db;
        }

        public async Task<int> AddAsync(Dto.User user)
        {
            try
            {
                _db.Users.Add(converts.UserConvert.ToUser(user));
                int x = await _db.SaveChangesAsync();
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Dto.User>> SelectAllAsync()
        {
            try
            {
                var models = await _db.Users.Where(c => c.IsDelete != true).Include(u=>u.Lendings).ToListAsync();

                return converts.UserConvert.ToListUserDto(models);
            
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<Dto.User> SelectByNameAndPassword(string name,string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync((x) => x.Name == name && x.Password == password);
            if (user == null)
                return null;
            return converts.UserConvert.ToUserDto(user);
        }
        public async Task<int> DeleteAsync(int id)
        {
            var c = await _db.Users.FirstOrDefaultAsync(c => c.Id == id);
            if (c == null)
                return -1;
            else
            {
                c.IsDelete = true;
                int x = await _db.SaveChangesAsync();
                return x;
            }
        }
        public async Task<int> UpdateAsync(int id, Dto.User user)
        {
            var c = await _db.Users.FirstOrDefaultAsync(c => c.Id == id);
            if (c == null)
                return -1;

            else
            {
                c.Cvv = user.Cvv;
                c.Id = user.Id;
                c.IsManager = user.IsManager;
                c.Name = user.Name;
                c.NumCreditCard = user.NumCreditCard;
                c.Password = user.Password;
                c.Phone = user.Phone;
                c.Validity = user.Validity;
                int x = await _db.SaveChangesAsync();
                return x;
            }
        }

        public async Task<int> AddLending(int id,Dto.Lending lending)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return -1;
            else
                 user.Lendings.Add(Convert.LendingConvert.ToLending(lending));
            int x = await _db.SaveChangesAsync();
            return x;
        }
    }
}
