using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class User
    {
        private readonly Dal.Users _dalU;
        public User(Dal.Users u) {  _dalU = u; }
        public async Task<int> AddAsync(Dto.User u)
        {
            return await _dalU.AddAsync(u);
        }
        public async Task<List<Dto.User>> SelectAllAsync()
        {
            var q1 = await _dalU.SelectAllAsync();
            //יתכן שפה תופיע לוגיקה
            return q1;
        }

        public async Task<int> UpdateAsync(int id, Dto.User u)
        {
            //פה נכתוב בדיקות תקינות למשל
            return await _dalU.UpdateAsync(id, u);
        }
        public async Task<int> DeleteAsync(int u)
        { //פה נכתוב בדיקות תקינות למשל
            return await _dalU.DeleteAsync(u);
        }

        public async Task<int> AddLending(int id,Dto.Lending lending)
        {
            return await _dalU.AddLending(id, lending);
        }
        public async Task<Dto.User> SelectBynameAndPassword(string name,string password)
        {
            return await _dalU.SelectByNameAndPassword(name, password);
        }
    }
}
