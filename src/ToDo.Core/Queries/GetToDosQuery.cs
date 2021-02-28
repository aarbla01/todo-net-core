using MediatR;
using System;
using ToDo.Core.Dtos;

namespace ToDo.Core.Queries
{
    public class GetToDosQuery : IRequest<GetToDosQueryOutput>
    {
    }

    public class GetToDosQueryOutput
    {
        public GetToDosQueryOutput(ToDoDto[] toDos)
        {
            ToDos = toDos ?? throw new ArgumentNullException(nameof(toDos));
        }

        public ToDoDto[] ToDos { get; }
    }
}
