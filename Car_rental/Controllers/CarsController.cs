using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Car_rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        Bll.Cars Cars;
        public CarsController(Bll.Cars cars) { 
            Cars = cars;
        }
        [HttpGet]
        public async Task<List<Dto.Car>> GetAsync()
        {
            return await Cars.SelectAllAsync();
        }
        [HttpGet("{code}")]
        public async Task<Dto.Car> GetCar(int code)
        {
            return await Cars.SelectOne(code);
        }
        [HttpDelete("{code}")]
        public async Task<int> Delete(int code)
        {
            return await  Cars.DeleteAsync(code);
        }
        [HttpPut]
        public async Task<int> Put(Dto.Car car)
        {
            return await Cars.AddAsync(car);
        }
        [HttpPost]
        //public async Task<int> Update_ava(int code,bool ava)
        //{
        //    return await Cars.Update_ava_Async(code, ava);
        //}

        [HttpPost("img")]
        public async Task<int> Update_img(int code,string img)
        {
            return await Cars.Update_price_Async(code, img);
        }
    }
}
