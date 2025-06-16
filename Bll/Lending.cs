using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Lending
    {
        private readonly Dal.Lendings _dalL;
        public Lending(Dal.Lendings dalL) { _dalL = dalL; }
        public async Task<int> AddAsync(Dto.Lending r)
        {
            return await _dalL.AddAsync(r);
        }
        public async Task<List<Dto.Lending>> SelectAllAsync()
        {
            var q1 = await _dalL.SelectAllAsync();
            //יתכן שפה תופיע לוגיקה
            return q1;
        }
       
        public async Task<int> UpdateReturnAsync(int code)
        {
            //פה נכתוב בדיקות תקינות למשל
            return await _dalL.UpdateReturnAsync(code);
        }
        public async Task<int> DeleteAsync(int l)
        { //פה נכתוב בדיקות תקינות למשל
            return await _dalL.DeleteAsync(l);
        }

    }
}
