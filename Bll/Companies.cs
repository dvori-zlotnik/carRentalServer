using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Companies
    {
        IDal.IDal<Dto.Company> idal;
        public Companies(IDal.IDal<Dto.Company> dal)
        {
            idal = dal;
        }
        public async Task<List<Dto.Company>> SelectAllAsync()
        {
            return await idal.SelectAllAsync();
        }

        public async Task<int> AddAsync(Dto.Company company)
        {
            return await idal.AddAsync(company);
        }

        public  async Task<int> DeleteAsync(int code)
        {
            return await idal.DeleteAsync(code);
        }
    }
}
