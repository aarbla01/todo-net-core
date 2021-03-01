﻿using MediatR;
using System;

namespace ToDo.Core.Commands
{
    public class CompleteToDoCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
