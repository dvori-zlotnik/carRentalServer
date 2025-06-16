using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Models
    {
        IDal.IDal<Dto.Model> dal;
        public Models(IDal.IDal<Dto.Model> dal)
        {
            this.dal = dal;
        }
        public async Task<List<Dto.Model>> SelectAllAsync()
        {
            var models = await dal.SelectAllAsync();
            return models;
        }

        public async Task<int> DeleteAsync(int code)
        {
            int x = await dal.DeleteAsync(code);
            return x;
        }

        public async Task<int> AddAsync(Dto.Model model)
        {
            int x= await dal.AddAsync(model);
            return x;
        }
    }
}
