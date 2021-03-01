using System.Threading;
using System.Threading.Tasks;

namespace ToDo.Core.Services
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
