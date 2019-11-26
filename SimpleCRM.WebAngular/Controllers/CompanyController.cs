using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;

namespace SimpleCRM.WebAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _companyService.GetCompanyListAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var company = await _companyService.GetCompanyAsync(id);

            if (company.Id != 0)
                return Ok(company);
            else
                return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CompanyDto company)
        {
            bool success = await _companyService.AddCompanyAsync(company);
            if (success)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CompanyDto company)
        {
            await _companyService.UpdateCompanyAsync(id, company);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteCompanyAsync(id);

            return NoContent();
        }


        // ------------------------------------------------------------
        // Find company details via external resources

        [Route("[action]/{companyCode}")]
        [HttpGet]
        public async Task<IActionResult> getCompaniesExternalByCode(string companyCode)
        {
            return Ok(await _companyService.GetCompanyExternal(companyCode));
        }

        [Route("[action]/{title}")]
        [HttpGet]
        public async Task<IActionResult> getCompaniesExternalByTitle(string title)
        {
            return Ok(await _companyService.GetCompanyExternalByTitle(title));
        }

        [Route("[action]/{url}")]
        [HttpGet]
        public async Task<IActionResult> getCompanyExternalDetails(string url)
        {
            return Ok(await _companyService.GetCompanyExternalDetails(url));
        }
    }
}