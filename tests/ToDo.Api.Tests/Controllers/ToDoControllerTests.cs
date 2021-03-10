using AutoBogus;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using ToDo.Api.Controllers;
using ToDo.Core.Commands;
using ToDo.Core.Queries;

namespace ToDo.Api.Tests.Controllers
{
    [TestClass]
    public class ToDoControllerTests
    {
        [TestMethod]
        public async Task GetToDos_ToDosExist_AllToDosReturned()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Strict);
            var getToDosQueryOutput = AutoFaker.Generate<GetToDosQueryOutput>();
            mocker.Use<IMediator>(x => x.Send(It.IsNotNull<GetToDosQuery>(), default) == Task.FromResult(getToDosQueryOutput));
            var toDoController = mocker.CreateInstance<ToDoController>();

            // Act
            var result = await toDoController.GetToDos();

            // Assert
            mocker.VerifyAll();
            result.Should().NotBeNull();
            var okayResult = result as OkObjectResult;
            okayResult.Should().NotBeNull();
            okayResult.StatusCode.Should().Be(200);
            okayResult.Value.Should().NotBeNull();
            okayResult.Value.Should().Be(getToDosQueryOutput);
        }

        [TestMethod]
        public async Task AddToDo_ToDoAdded_Status201Returned()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Strict);
            
            AddToDoCommand request = AutoFaker.Generate<AddToDoCommand>();
            mocker.Use<IMediator>(x => x.Send(request, default) == Unit.Task);

            var toDoController = mocker.CreateInstance<ToDoController>();

            // Act
            var result = await toDoController.AddToDo(
                request);

            // Assert
            mocker.VerifyAll();
            result.Should().NotBeNull();
            var createdResult = result as CreatedAtActionResult;
            createdResult.Should().NotBeNull();
            createdResult.StatusCode.Should().Be(StatusCodes.Status201Created);
            createdResult.Value.Should().NotBeNull();
            createdResult.Value.Should().Be(request);
            createdResult.ActionName.Should().NotBeNull();
            createdResult.ActionName.Should().Be(nameof(ToDoController.GetToDosById));
            createdResult.RouteValues.Should().NotBeNull();
            createdResult.RouteValues.Should().Contain("id", request.Id);
        }

        [TestMethod]
        public async Task GetToDosById_ExistingToDo_Status200Returned()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Strict);

            Guid id = Guid.NewGuid();
            GetToDoByIdQueryOutput getToDoByIdQueryOutput = AutoFaker.Generate<GetToDoByIdQueryOutput>();
            mocker.Use<IMediator>(x => x.Send(It.Is<GetToDoByIdQuery>(y=> y.Id == id), default) == Task.FromResult(getToDoByIdQueryOutput));
            var toDoController = mocker.CreateInstance<ToDoController>();
            // Act
            var result = await toDoController.GetToDosById(
                id);

            // Assert
            mocker.VerifyAll();
            result.Should().NotBeNull();
            var okayResult = result as OkObjectResult;
            okayResult.Should().NotBeNull();
            okayResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okayResult.Value.Should().NotBeNull();
            okayResult.Value.Should().Be(getToDoByIdQueryOutput);
        }

        [TestMethod]
        public async Task CompleteToDo_ExistingToDo_Status200Returned()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Strict);
            CompleteToDoCommand request = AutoFaker.Generate<CompleteToDoCommand>();
            mocker.Use<IMediator>(x => x.Send(request, default) == Unit.Task);
            var toDoController = mocker.CreateInstance<ToDoController>();
            

            // Act
            var result = await toDoController.CompleteToDo(
                request);

            // Assert
            mocker.VerifyAll();
            result.Should().NotBeNull();
            var okayResult = result as OkObjectResult;
            okayResult.Should().NotBeNull();
            okayResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [TestMethod]
        public async Task DeleteToDo_ExistingToDo_Status200Returned()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Strict);
            
            Guid id = Guid.NewGuid();
            mocker.Use<IMediator>(x => x.Send(It.Is<DeleteToDoCommand>(y => y.Id == id), default) == Unit.Task);

            var toDoController = mocker.CreateInstance<ToDoController>();

            // Act
            var result = await toDoController.DeleteToDo(
                id);

            // Assert
            mocker.VerifyAll();
            result.Should().NotBeNull();
            var okayResult = result as OkObjectResult;
            okayResult.Should().NotBeNull();
            okayResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
