using MediatR;
using System;
using ToDo.Core.Dtos;

namespace ToDo.Core.Queries
{
    public class GetToDoByIdQuery : IRequest<GetToDoByIdQueryOutput>
    {
        public Guid Id { get; set; }
    }
    public class GetToDoByIdQueryOutput
    {
        public GetToDoByIdQueryOutput(ToDoDto toDo)
        {
            ToDo = toDo ?? throw new ArgumentNullException(nameof(toDo));
        }

        public ToDoDto ToDo { get; }
    }
}
