using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriveTypesController : ControllerBase
    {
        Bll.DriveTypes DriveTypes;
        public DriveTypesController(Bll.DriveTypes driveTypes)
        {
            DriveTypes = driveTypes;
        }
        [HttpGet]
        public async Task<List<Dto.DriveType>> GetAsync()
        {
            return await DriveTypes.SelectAllAsync();
        }
        [HttpPut]
        public async Task<int> PutAsync(Dto.DriveType driveType)
        {
            return await DriveTypes.AddAsync(driveType);
        }
        [HttpDelete("{code}")]
        public async Task<int> DeleteAsync(int code)
        {
            return await DriveTypes.DeleteAsync(code);
        }
    }
}
