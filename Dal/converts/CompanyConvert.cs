using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converts
{
    public class CompanyConvert
    {
        public static Dto.Company to_dto(Models.Company company)
        {
            Dto.Company company1 = new Dto.Company();
            company1.Name = company.Name;
            company1.Image = company.Image;
           company1.Code = company.Code;
            return company1;
        }
        public static Models.Company to_dal(Dto.Company company) 
        {
            Models.Company c = new Models.Company();
            c.Name = company.Name;
            c.Image = company.Image;
            return c;
        }
        public static List<Dto.Company> to_list_dto(List<Models.Company> list) 
        {
            List<Dto.Company> companies = new List<Dto.Company>();
            foreach (Models.Company company in list) 
            {
                companies.Add(to_dto(company));
            }
            return companies;
        }
    }
}
