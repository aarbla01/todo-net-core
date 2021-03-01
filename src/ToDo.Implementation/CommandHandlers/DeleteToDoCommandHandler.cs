using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Commands;
using ToDo.Core.Services;

namespace ToDo.Implementation.CommandHandlers
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand>
    {
        public DeleteToDoCommandHandler(IToDoRepository toDoRepository, IUnitOfWork unitOfWork)
        {
            ToDoRepository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        protected IToDoRepository ToDoRepository { get; }
        protected IUnitOfWork UnitOfWork { get; }

        public async Task<Unit> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            var toDo = await ToDoRepository.Get(request.Id, cancellationToken);
            if (toDo is null)
                throw new InvalidOperationException($"Failed to find {nameof(toDo)} with {nameof(request.Id)}: {request.Id}");
            toDo.Delete();
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
