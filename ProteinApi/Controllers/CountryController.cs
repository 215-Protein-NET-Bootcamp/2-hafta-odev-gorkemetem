using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProteinApi.Data;
using ProteinApi.Dto;
using ProteinApi.Service;
using Serilog;
using System.Threading.Tasks;

namespace ProteinApi.Controllers
{
    [Route("api/v1/tech/[controller]")]
    [ApiController]
    public class CountryController : BaseController<CountryDto, Country>
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService CountryService, IMapper mapper) : base(CountryService, mapper)
        {
            _countryService = CountryService;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Log.Information($"{User.Identity?.Name}: get Country.");

            var result = await _countryService.GetAllAsync();

            if (!result.Success)
                return BadRequest(result);

            if (result.Response is null)
                return NoContent();

            return Ok(result);
        }


        [HttpGet("{id:int}")]
        public new async Task<IActionResult> GetByIdAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: get a Country with Id is {id}.");

            return await base.GetByIdAsync(id);
        }

        [HttpPost]
        public new async Task<IActionResult> CreateAsync([FromBody] CountryDto resource)
        {
            Log.Information($"{User.Identity?.Name}: create a Author.");

            //resource.CreatedBy = User.Identity?.Name;

            var insertResult = await _countryService.InsertAsync(resource);

            if (!insertResult.Success)
                return BadRequest(insertResult);

            return StatusCode(201, insertResult);
        }

        [HttpPut("{id:int}")]
        public new async Task<IActionResult> UpdateAsync(int id, [FromBody] CountryDto resource)
        {
            Log.Information($"{User.Identity?.Name}: update a Country with Id is {id}.");

            return await base.UpdateAsync(id, resource);
        }


        [HttpDelete("{id:int}")]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: delete a Country with Id is {id}.");

            return await base.DeleteAsync(id);
        }

    }
}
