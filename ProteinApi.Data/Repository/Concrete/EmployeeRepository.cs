using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Employee> GetByIdAsync(int id)
        {
            return await Context.employee.AsSplitQuery().SingleOrDefaultAsync(x => x.EmpId == id);
        }
    }
}
