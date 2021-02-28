using System;

namespace ToDo.Core.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
        bool IsDeleted { get; }
        DateTimeOffset CreatedDateTime { get; }
    }
}
