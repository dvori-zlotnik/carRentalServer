using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendingsController : ControllerBase
    {
        private readonly Bll.Lending _bllL;
        public LendingsController(Bll.Lending bllL) { _bllL = bllL; }
        [HttpGet]
        public async Task<List<Dto.Lending>> SelectAll()
        {
            return await _bllL.SelectAllAsync();
        }
        [HttpPut]
        public async Task<int> AddLeding(Dto.Lending leding)
        {
            return await _bllL.AddAsync(leding);
        }
        [HttpPost]
        public async Task<int> Return(int code)
        {
            return await _bllL.UpdateReturnAsync(code);
        }

    }
}
