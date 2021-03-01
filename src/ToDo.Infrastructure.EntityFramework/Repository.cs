using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Entities;
using ToDo.Core.Services;

namespace ToDo.Infrastructure.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Repository(DbContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
        }

        protected DbContext Context { get; }
        protected DbSet<TEntity> Set { get; }

        public async Task<TEntity> Get(Guid id, CancellationToken cancellationToken)
        {
            return await Set.SingleOrDefaultAsync(x => x.Id == x.Id && !x.IsDeleted, cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await Set.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
        }

        public void Insert(TEntity item)
            => Context.Entry(item).State = EntityState.Added;

        public void Update(TEntity item)
            => Context.Entry(item).State = EntityState.Modified;
    }
}
