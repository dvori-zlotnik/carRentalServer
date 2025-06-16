using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converts
{
    internal class UserConvert
    {
        public static Dto.User ToUserDto(Models.User user)
        {
            Dto.User uNew = new Dto.User();
            uNew.Cvv = user.Cvv;
            uNew.Id = user.Id;
            uNew.IsManager = user.IsManager;
            uNew.Name = user.Name;
            uNew.NumCreditCard = user.NumCreditCard;
            uNew.Password = user.Password;
            uNew.Phone = user.Phone;
            uNew.Validity = user.Validity;
            //if(user.Lendings != null)
            //{
            //    uNew.Lendings = LendingConvert.ToListLendingDto(user.Lendings.ToList());
            //}
            
            return uNew;
        }

        public static Models.User ToUser (Dto.User user)
        {
            Models.User uNew= new Models.User();
            uNew.Cvv = user.Cvv;
            uNew.Id = user.Id;
            uNew.IsManager = user.IsManager;
            uNew.Name = user.Name;
            uNew.NumCreditCard = user.NumCreditCard;
            uNew.Password = user.Password;
            uNew.Phone = user.Phone;
            uNew.Validity = user.Validity;
            return uNew;
        }
        public static List<Dto.User> ToListUserDto(List<Models.User> luser)
        {
            List<Dto.User> lnew = new List<Dto.User>();
            foreach (var item in luser)
            {
                lnew.Add(ToUserDto(item));
            }
            return lnew;
        }
    }
}
