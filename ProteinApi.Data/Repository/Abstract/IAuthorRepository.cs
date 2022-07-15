using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<IEnumerable<Author>> FindByNameAsync(string filterName);
        Task<int> TotalRecordAsync();
    }
}
