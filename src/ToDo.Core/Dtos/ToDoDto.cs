using System;

namespace ToDo.Core.Dtos
{
    public class ToDoDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public static ToDoDto MapToDto(Entities.ToDo toDo)
            => toDo is null ? 
            throw new ArgumentNullException(nameof(toDo)) :
            new ToDoDto
            {
                Id = toDo.Id,
                Description = toDo.Description,
                IsComplete = toDo.IsComplete
            };
    }
}
