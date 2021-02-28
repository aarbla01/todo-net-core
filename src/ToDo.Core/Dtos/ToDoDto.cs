using System;

namespace ToDo.Core.Dtos
{
    public class ToDoDto
    {
        public Guid Id { get; }
        public string Description { get; }
        public bool IsComplete { get; }
    }
}
