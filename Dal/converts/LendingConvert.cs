using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Convert
{
    internal class LendingConvert
    {
        public static Dto.Lending ToLendingDto(Models.Lending lending)
        {
            Dto.Lending lNew= new Dto.Lending();
            lNew.Code = lending.Code;
            lNew.Date = lending.Date;
            lNew.Hour = lending.Hour;
            lNew.IdUser = lending.IdUser;
            lNew.ReturnDate = lending.ReturnDate;
            lNew.ReturnHour = lending.ReturnHour;
            lNew.ReturnCar = lending.ReturnCar;
            if (lending.IdUserNavigation != null)
                lNew.userName = lending.IdUserNavigation.Name;
            if(lending.CodeCarNavigation != null)
            lNew.code_car = lending.CodeCar;
            
            return lNew;
        }
        public static Models.Lending ToLending(Dto.Lending lending)
        {
            Models.Lending lNew= new Models.Lending();
            lNew.Date = lending.Date;
            lNew.Hour = lending.Hour;
            lNew.IdUser = lending.IdUser;
           lNew.ReturnHour = lending.ReturnHour;
            lNew.ReturnDate = lending.ReturnDate;
            lNew.CodeCar = lending.code_car;
            return lNew;
        }
        public static List<Dto.Lending> ToListLendingDto(List<Models.Lending> llendings)
        {
            List<Dto.Lending> lnew = new List<Dto.Lending>();
            foreach (var item in llendings)
            {
                lnew.Add(ToLendingDto(item));
            }
            return lnew;
        }
    }
}
