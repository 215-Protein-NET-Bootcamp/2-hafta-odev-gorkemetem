using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProteinApi.Data;
using ProteinApi.Dto;
using ProteinApi.Service;
using Serilog;
using System.Threading.Tasks;

namespace ProteinApi.Controllers
{
    [Route("api/v1/protein/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<EmployeeDto, Employee>
    {

        public EmployeeController(IEmployeeService EmployeeService, IMapper mapper) : base(EmployeeService, mapper)
        {
            
        }

        [HttpGet("{id:int}")]
        public new async Task<IActionResult> GetByIdAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: get a Employee with Id is {id}.");

            return await base.GetByIdAsync(id);
        }

        [HttpPost]
        public new async Task<IActionResult> CreateAsync([FromBody] EmployeeDto resource)
        {
            Log.Information($"{User.Identity?.Name}: create a Employee.");

            //resource.CreatedBy = User.Identity?.Name;

            return await base.CreateAsync(resource);
        }

        [HttpPut("{id:int}")]
        public new async Task<IActionResult> UpdateAsync(int id, [FromBody] EmployeeDto resource)
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
