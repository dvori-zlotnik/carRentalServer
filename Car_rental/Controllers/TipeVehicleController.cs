using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipeVehicleController : ControllerBase
    {
        Bll.TypeVehicles TypeVehicles; 
        public TipeVehicleController(Bll.TypeVehicles typeVehicles)
        {
            TypeVehicles = typeVehicles;
        }
        [HttpGet]
        public async Task<List<Dto.TypeVehicle>> GetAsync()
        {
            return await TypeVehicles.SelectAllAsync();
        }

        [HttpPut]
        public async Task<int> PutAsync(Dto.TypeVehicle typeVehicle)
        {
            return await TypeVehicles.AddAsync(typeVehicle);
        }
        [HttpDelete("{code}")]
        public async Task<int> DeleteAsync(int code)
        {
            return await TypeVehicles.DeleteAsync(code);
        }
         
    }
}
