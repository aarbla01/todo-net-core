using System;

namespace ToDo.Core.Entities
{
    public abstract class EntityBase : IEntity
    {
        public EntityBase(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
        public bool IsDeleted { get; }
        public DateTimeOffset CreatedDateTime { get; } = DateTimeOffset.UtcNow;
    }
}
