using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Entities;

namespace ToDo.Core.Services
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> Get(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken);
        void Insert(TEntity entity);
        void Update(TEntity bookEntity);
    }
}
