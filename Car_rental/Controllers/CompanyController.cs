using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        Bll.Companies Companies;
        public CompanyController(Bll.Companies companies) 
        {
            this.Companies = companies;
        }
        [HttpGet]
        public  Task<List<Dto.Company>> GetCompaniesAsync()
        {
            return Companies.SelectAllAsync();
        }
        [HttpPut]
        public async Task<int> PutAsync(Dto.Company company)
        {
            return await Companies.AddAsync(company);
        }
        [HttpDelete("{code}")]
        public async Task<int> DeleteAsync(int code)
        {
            return await Companies.DeleteAsync(code);
        }

    }
}
