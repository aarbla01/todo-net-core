using AutoBogus;
using FluentAssertions;
using MediatR;
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
        public async Task AddToDo_ToDoAdded_Status200Returned()
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
            var okayResult = result as OkObjectResult;
            okayResult.Should().NotBeNull();
            okayResult.StatusCode.Should().Be(200);
            okayResult.Value.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetToDosById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mocker = new AutoMocker();
            var toDoController = mocker.Get<ToDoController>();
            Guid id = default(global::System.Guid);

            // Act
            var result = await toDoController.GetToDosById(
                id);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task CompleteToDo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mocker = new AutoMocker();
            var toDoController = mocker.Get<ToDoController>();
            CompleteToDoCommand request = null;

            // Act
            var result = await toDoController.CompleteToDo(
                request);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task DeleteToDo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mocker = new AutoMocker();
            var toDoController = mocker.Get<ToDoController>();
            Guid id = default(global::System.Guid);

            // Act
            var result = await toDoController.DeleteToDo(
                id);

            // Assert
            Assert.Fail();
        }
    }
}
