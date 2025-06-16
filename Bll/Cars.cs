using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Cars
    {
        IDal.ICar ICar;

        public Cars(IDal.ICar ICar)
        {
            this.ICar = ICar;
        }
        public async Task<List<Dto.Car>> SelectAllAsync()
        {
            var cars = await ICar.SelectAllAsync();
            return cars;
        }

        public async Task<Dto.Car> SelectOne(int code)
        {
            return await ICar.SelectOne(code);
        }
        public async Task<int> AddAsync(Dto.Car city)
        {
            int x = await ICar.AddAsync(city);
            return x;
        }

        //public async Task<int> Update_ava_Async(int code, bool ava)
        //{
        //    int x = await ICar.Update_ava_Async(code, ava);
        //    return x;
        //}
        public async Task<int> Update_balance_Async(int code,short balance)
        {
            int x = await ICar.Update_balance_Async(code, balance);
            return x;
        }
        public async Task<int> Update_price_Async(int code,string img)
        {
            int x = await ICar.Update_img_Async(code, img);
            return x;
        }
        public async Task<int> DeleteAsync(int code)
        {
            int x = await ICar.DeleteAsync(code);
            return x;
        }
    }
}

