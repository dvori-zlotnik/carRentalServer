using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        Bll.Cities Cities;
        public CitiesController(Bll.Cities cities)
        {
            this.Cities = cities;
        }
        [HttpGet]
        public async Task<List<Dto.City>> GetAsync()
        {

            return await Cities.SelectAllAsync();
        }

        [HttpPut]
        public async Task<int> PutAsync(Dto.City city)
        {
            return await Cities.AddAsync(city);
        }
        [HttpDelete("{code}")]
        public async Task<int> DeleteAsync(int code)
        {
            return await Cities.DeleteAsync(code);
        }
    }
}
