using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Convert
{
    internal class RestitutionConvert
    {
        public static Dto.Restitution ToRestitutionDto(Models.Restitution restitution)
        {
            Dto.Restitution rNew = new Dto.Restitution();
            rNew.Balance = restitution.Balance;
            rNew.Hour = restitution.Hour;
            rNew.CodeLending = restitution.CodeLending;
            rNew.Code = restitution.Code;
            rNew.Date = restitution.Date;
            rNew.Paid = restitution.Paid;
            rNew.TotalPayable = restitution.TotalPayable;
            rNew.CodeLendingNavigation = rNew.CodeLendingNavigation;
            return rNew;
        }
        public static Models.Restitution ToRestitution(Dto.Restitution restitution)
        {
            Models.Restitution rNew = new Models.Restitution();
            rNew.Balance = restitution.Balance;
            rNew.Hour = restitution.Hour;
            rNew.CodeLending = restitution.CodeLending;
            rNew.Code = restitution.Code;
            rNew.Date = restitution.Date;
            rNew.Paid = restitution.Paid;
            rNew.TotalPayable = restitution.TotalPayable;
            rNew.CodeLendingNavigation = rNew.CodeLendingNavigation;
            return rNew;
        }
    }
}

