using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Models_:IDal.IDal<Dto.Model>
    {
        private readonly CarRentalContext _db;
        public Models_(CarRentalContext db)
        {
           _db = db;
        }

        public async Task<List<Dto.Model>> SelectAllAsync()
        {
            try
            {
                var models = _db.Models.Where(c => c.IsDelete != true).Include(m=>m.TypeVehiclesNavigation).Include(m => m.CodeCompanyNavigation).Include(m => m.DriveTypeNavigation).ToList();
                return  converts.ModelConvert.to_list_dto(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddAsync(Dto.Model model)
        {
            _db.Models.Add(converts.ModelConvert.To_dal(model));
            int x = _db.SaveChanges();
            return x;
        }

        public async Task<int> DeleteAsync(int code)
        {
            var model = await _db.Models.FirstOrDefaultAsync(c => c.Code == code);
            if (model != null)
            {
                model.IsDelete = false;
                int x = await _db.SaveChangesAsync();
                return x;
            }
            return -1;
        }
    }
}
