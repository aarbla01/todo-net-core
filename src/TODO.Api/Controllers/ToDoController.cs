using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDo.Core.Commands;
using ToDo.Core.Queries;

namespace ToDo.Api.Controllers
{
    [ApiController]
    public class ToDoController : Controller
    {
        public ToDoController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected IMediator Mediator { get; }

        [HttpGet]
        [Route("todos")]
        [ProducesResponseType(typeof(GetToDosQueryOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetToDos() => Ok(await Mediator.Send(new GetToDosQuery()));

        [HttpPost]
        [Route("todos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddToDo([FromBody]AddToDoCommand request) => Ok(await Mediator.Send(request));

        [HttpGet]
        [Route("todos/{id}")]
        [ProducesResponseType(typeof(GetToDoByIdQueryOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetToDosById([FromQuery] GetToDoByIdQuery request) => Ok(await Mediator.Send(request));

        [HttpPost]
        [Route("todos/complete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CompleteToDo([FromBody] CompleteToDoCommand request) => Ok(await Mediator.Send(request));
    }
}
