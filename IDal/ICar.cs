using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
    public interface ICar:IDal<Dto.Car>
    {
        Task<int> Update_ava_Async(short? code, bool available);
        Task<int> Update_balance_Async(int code, short balance);
        Task<int> Update_img_Async(int code, string img);
        Task<Dto.Car> SelectOne(int code);


    }
}
