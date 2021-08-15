using System;
using Castle.Core.Logging;
using CommandsApi.Controllers;
using CommandsApi.Data;
using CommandsApi.DTOs;
using CommandsApi.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CommandsApi.UnitTests
{
    public class CommandControllerTests
    {
        private readonly Mock<ICommandData> repoStub = new();
        private readonly Mock<ILogger<CommandController>> loggerStub = new();
        private Random rnd = new Random();
        // UnitOfWork_StateUnderTest_ExpectedBehaviour
        [Fact]
        public void GetCommandById_WithNotExistingCommand_ReturnsNotFound()
        {
            repoStub.Setup(repo => repo.GetCommandById(It.IsAny<int>())).Returns((Command)null);

            var controller = new CommandController(repoStub.Object, loggerStub.Object);

            var result = controller.GetCommandById(rnd.Next(1, 20));

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetCommandById_WithExistingCommand_ReturnsCommand()
        {
            var expected = CreateRandomCommand();
            repoStub.Setup(repo => repo.GetCommandById(It.IsAny<int>())).Returns(expected);
            
            var controller = new CommandController(repoStub.Object, loggerStub.Object);

            var result = controller.GetCommandById(rnd.Next(1, 20));

            //Fluent Assertions nuget package
                //doesnt compare dto directly with command model; it focuses on properties
            result.Value.Should().BeEquivalentTo(expected,
                options=> options.ComparingByMembers<Command>());
            
        }
        [Fact]
        public void GetCommands_WithCommandToCreate_ReturnsCreatedCommand()
        {
            var expectedCommands = new[] { CreateRandomCommand(), CreateRandomCommand(), CreateRandomCommand() };

            repoStub.Setup(repo => repo.GetAllCommands()).Returns(expectedCommands);

            var controller = new CommandController(repoStub.Object, loggerStub.Object);

            var actualCommands = controller.GetAll();
            actualCommands.Should().BeEquivalentTo(expectedCommands,
                options => options.ComparingByMembers<Command>());
            
        }

        [Fact]
        public void CreateCommand_WithExistingCommands_ReturnsAllCommands()
        {
            var command = new CommandCreateDto()
            {
                CommandName = "creating test item",
                Description = "for testing create method",
                Platform = "testing"
            };
            var controller = new CommandController(repoStub.Object, loggerStub.Object);
            var result = controller.CreateCommand(command);

            var createdCommand = (result.Result as CreatedAtActionResult)?.Value as CommandDto;
            command.Should().BeEquivalentTo(
                createdCommand,
                options => options.ComparingByMembers<CommandDto>().ExcludingMissingMembers());
            createdCommand.Should().NotBeNull();

        }

        [Fact]
        public void UpdateCommand_WithExistingCommand_ReturnNoContent()
        {
            var expected = CreateRandomCommand();
            repoStub.Setup(repo => repo.GetCommandById(It.IsAny<int>())).Returns(expected);

            var commandId = expected.Id;
            var toUpdate = new CommandUpdateDto()
            {
                CommandName = "update method",
                Description = "testing update method",
                Platform = "tests"
            };

            var controller = new CommandController(repoStub.Object, loggerStub.Object);

            var result = controller.UpdateCommand(commandId, toUpdate);

            result.Should().BeOfType<NoContentResult>();
        }
        [Fact]
        public void DeleteCommand_WithExistingCommand_ReturnNoContent()
        {
            var expected = CreateRandomCommand();
            repoStub.Setup(repo => repo.GetCommandById(It.IsAny<int>())).Returns(expected);

            var controller = new CommandController(repoStub.Object, loggerStub.Object);

            var result = controller.DeleteCommand(expected.Id);

            result.Should().BeOfType<NoContentResult>();
        }
        private Command CreateRandomCommand()
        {
            return new()
            {
                Id = rnd.Next(1,20),
                CommandName = "testCommandName",
                Description = "This command was made for the sole purpose of testing ",
                Platform = "testing platform"
            };
        }
    }
}
