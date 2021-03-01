using MediatR;
using System;

namespace ToDo.Core.Commands
{
    public class DeleteToDoCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
