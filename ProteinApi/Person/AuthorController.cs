using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProteinApi.Data;
using ProteinApi.Dto;
using ProteinApi.Service;
using Serilog;
using System.Threading.Tasks;

namespace ProteinApi
{
    [Route("api/v1/tech/[controller]")]
    [ApiController]
    public class AuthorController : BaseController<AuthorDto, Author>
    {
        private readonly IAuthorService AuthorService;

        public AuthorController(IAuthorService AuthorService, IMapper mapper) : base(AuthorService, mapper)
        {
            this.AuthorService = AuthorService;
        }
        
        

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Log.Information($"{User.Identity?.Name}: get Author.");           

            var result = await AuthorService.GetAllAsync();

            if (!result.Success)
                return BadRequest(result);

            if (result.Response is null)
                return NoContent();

            return Ok(result);
        }


        [HttpGet("{id:int}")]      
        public new async Task<IActionResult> GetByIdAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: get a Author with Id is {id}.");

            return await base.GetByIdAsync(id);
        }

        [HttpPost]       
        public new async Task<IActionResult> CreateAsync([FromBody] AuthorDto resource)
        {
            Log.Information($"{User.Identity?.Name}: create a Author.");

            resource.CreatedBy = User.Identity?.Name;

            var insertResult = await AuthorService.InsertAsync(resource);

            if (!insertResult.Success)
                return BadRequest(insertResult);

            return StatusCode(201, insertResult);
        }

        [HttpPut("{id:int}")]
        public new async Task<IActionResult> UpdateAsync(int id, [FromBody] AuthorDto resource)
        {
            Log.Information($"{User.Identity?.Name}: update a Author with Id is {id}.");

            return await base.UpdateAsync(id, resource);
        }

    
        [HttpDelete("{id:int}")]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: delete a Author with Id is {id}.");

            return await base.DeleteAsync(id);
        }

    }
}
