using ProteinApi.Base;
using ProteinApi.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<(IEnumerable<Person> records, int total)> GetPaginationAsync(QueryResource pagination, PersonDto filterResource);
        Task<int> TotalRecordAsync();
    }
}
