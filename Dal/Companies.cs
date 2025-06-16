using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Companies:IDal.IDal<Dto.Company>
    {
        private readonly CarRentalContext _db;
        public Companies(CarRentalContext db) { _db = db; }
        public async Task<List<Dto.Company>> SelectAllAsync()
        {
            try
            {
                var companies = await _db.Companies.Where(c => c.IsDelete != true).ToListAsync();
                return converts.CompanyConvert.to_list_dto(companies);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> AddAsync(Dto.Company company)
        {
            _db.Companies.Add(converts.CompanyConvert.to_dal(company));
            int x = await _db.SaveChangesAsync();
            return x;
        }
        public async Task<int> DeleteAsync(int code)
        {
            var company = await _db.Companies.FirstOrDefaultAsync(x => x.Code == code);
            if (company != null)
            {
                company.IsDelete = true;
                int x = await _db.SaveChangesAsync();
                return x;
            }
            return -1;
        }
    }
}
