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
        public string Description { get; private set; }
        public DateTimeOffset? CompletedDateTime { get; private set; }
        public bool IsComplete => CompletedDateTime.HasValue;

        public void Complete()
        {
            CompletedDateTime = DateTimeOffset.UtcNow;
        }
    }
}
