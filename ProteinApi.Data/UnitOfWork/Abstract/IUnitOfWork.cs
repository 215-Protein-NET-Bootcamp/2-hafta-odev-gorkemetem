using System;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
    }
}
