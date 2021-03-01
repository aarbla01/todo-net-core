using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Dtos;
using ToDo.Core.Queries;
using ToDo.Core.Services;

namespace ToDo.Implementation.QueryHandlers
{
    public class GetToDosQueryHandler : IRequestHandler<GetToDosQuery, GetToDosQueryOutput>
    {
        public GetToDosQueryHandler(IToDoRepository toDoRepository)
        {
            ToDoRepository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
        }

        protected IToDoRepository ToDoRepository { get; }

        public async Task<GetToDosQueryOutput> Handle(GetToDosQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            var toDos = await ToDoRepository.GetAll(cancellationToken);
            var toDoDtos = toDos?.Select(ToDoDto.MapToDto)?.ToArray() ?? Array.Empty<ToDoDto>();
            return new GetToDosQueryOutput(toDoDtos);
        }
    }
}
