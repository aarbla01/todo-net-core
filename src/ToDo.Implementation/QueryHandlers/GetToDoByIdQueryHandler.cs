using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Dtos;
using ToDo.Core.Queries;
using ToDo.Core.Services;

namespace ToDo.Implementation.QueryHandlers
{
    public class GetToDoByIdQueryHandler : IRequestHandler<GetToDoByIdQuery, GetToDoByIdQueryOutput>
    {
        public GetToDoByIdQueryHandler(IToDoRepository toDoRepository)
        {
            ToDoRepository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
        }

        protected IToDoRepository ToDoRepository { get; }

        public async Task<GetToDoByIdQueryOutput> Handle(GetToDoByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            var toDo = await ToDoRepository.Get(request.Id, cancellationToken);
            if (toDo is null)
                throw new InvalidOperationException($"Failed to find {nameof(toDo)} with Id: {request.Id}");
            var toDoDto = ToDoDto.MapToDto(toDo);
            return new GetToDoByIdQueryOutput(toDoDto);
        }
    }
}
