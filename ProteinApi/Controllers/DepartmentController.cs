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
    public class DepartmentController : BaseController<DepartmentDto, Department>
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService DepartmentService, IMapper mapper) : base(DepartmentService, mapper)
        {
            _departmentService = DepartmentService;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Log.Information($"{User.Identity?.Name}: get Country.");

            var result = await _departmentService.GetAllAsync();

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
        public new async Task<IActionResult> CreateAsync([FromBody] DepartmentDto resource)
        {
            Log.Information($"{User.Identity?.Name}: create a _departmentService.");

            resource.CreatedBy = User.Identity?.Name;

            var insertResult = await _departmentService.InsertAsync(resource);

            if (!insertResult.Success)
                return BadRequest(insertResult);

            return StatusCode(201, insertResult);
        }

        [HttpPut("{id:int}")]
        public new async Task<IActionResult> UpdateAsync(int id, [FromBody] DepartmentDto resource)
        {
            Log.Information($"{User.Identity?.Name}: update a Department with Id is {id}.");

            return await base.UpdateAsync(id, resource);
        }


        [HttpDelete("{id:int}")]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: delete a Department with Id is {id}.");

            return await base.DeleteAsync(id);
        }

    }
}
