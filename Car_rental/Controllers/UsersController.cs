using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Bll.User _bllU;
        public UsersController(Bll.User bllU) { _bllU = bllU; }
        [HttpPut]
        public async Task<int> Put(Dto.User user)
        {
          
            return await _bllU.AddAsync(user);
        }
        [HttpGet]
        public async Task<List<Dto.User>> SelectAllAsync()
        {
            return await _bllU.SelectAllAsync();
        }
        [HttpGet("{name},{password}")]
        public async Task<Dto.User> SelectBy(string name, string password)
        {
            return await _bllU.SelectBynameAndPassword(name, password);
        }
    }
}
