using ProteinApi.Base;
using ProteinApi.Data;
using ProteinApi.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProteinApi.Service
{
    public interface IPersonService : IBaseService<PersonDto, Person>
    {
        Task<PaginationResponse<IEnumerable<PersonDto>>> GetPaginationAsync(QueryResource pagination, PersonDto filterResource);
    }
}
