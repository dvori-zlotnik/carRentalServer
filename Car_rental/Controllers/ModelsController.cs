using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Car_rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        Bll.Models Models;
        public ModelsController(Bll.Models models)
        {
            Models = models;
        }
        [HttpGet]
        public async Task<List<Dto.Model>> GetAsync()
        {
            return await Models.SelectAllAsync();
        }
        [HttpPut]
        public async Task<int> Putasync(Dto.Model model)
        {
            return await Models.AddAsync(model);
        }

        [HttpDelete("{code}")]
        public async Task<int> DeleteAsync(int code)
        {
            return await Models.DeleteAsync(code);
        }
    }
}
