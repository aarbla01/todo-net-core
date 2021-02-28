using System;

namespace ToDo.Core.Entities
{
    public class ToDo : EntityBase, IEntity
    {
        public ToDo(Guid id, string description, DateTimeOffset? completedDateTime)
            : base(id)
        {
            Description = description;
            CompletedDateTime = completedDateTime;
        }

        public string Description { get; }
        public DateTimeOffset? CompletedDateTime { get; }
        public bool IsComplete => CompletedDateTime.HasValue;
    }
}
