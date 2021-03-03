using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Services;

namespace ToDo.Infrastructure.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ToDoDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        protected DbContext DbContext { get; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
