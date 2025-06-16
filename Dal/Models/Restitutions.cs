using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Restitutions
    {
        private readonly CarRentalContext _db;
        public Restitutions(CarRentalContext db) { _db = db; }
        public async Task<int> AddAsync(Dto.Restitution restitution)
        {
            try
            {
                _db.Restitutions.Add(Convert.RestitutionConvert.ToRestitution(restitution));
                int x = await _db.SaveChangesAsync();
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
