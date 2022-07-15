using Microsoft.EntityFrameworkCore;
using ProteinApi.Base;
using ProteinApi.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext Context) : base(Context)
        {
        }

        public Task<(IEnumerable<Person> records, int total)> GetPaginationAsync(QueryResource pagination, PersonDto filterResource)
        {
            throw new System.NotImplementedException();
        }
        public override async Task<Person> GetByIdAsync(int id)
        {
            return await Context.Person.AsSplitQuery().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> TotalRecordAsync()
        {
            return await Context.Person.CountAsync();
        }
    }
}
