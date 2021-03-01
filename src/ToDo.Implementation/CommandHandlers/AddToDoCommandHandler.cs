using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Commands;
using ToDo.Core.Services;

namespace ToDo.Implementation.CommandHandlers
{
    public class AddToDoCommandHandler : IRequestHandler<AddToDoCommand>
    {
        public AddToDoCommandHandler(IToDoRepository toDoRepository, IUnitOfWork unitOfWork)
        {
            ToDoRepository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        protected IToDoRepository ToDoRepository { get; }
        protected IUnitOfWork UnitOfWork { get; }

        public async Task<Unit> Handle(AddToDoCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            var toDo = new Core.Entities.ToDo(request.Id, request.Description, null);
            ToDoRepository.Insert(toDo);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
