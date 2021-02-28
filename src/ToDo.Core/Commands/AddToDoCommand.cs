using MediatR;
using System;

namespace ToDo.Core.Commands
{
    public class AddToDoCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
