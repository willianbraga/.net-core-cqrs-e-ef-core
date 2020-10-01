using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo da Tarefa", "Willian", DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        public CreateTodoHandlerTests() { }

        [TestMethod]
        public void Given_a_invalid_command_must_stop_running()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);

            Assert.AreEqual(_result.Success, false);
        }
        
        [TestMethod]
        public void Given_a_valid_command_must_create_todo()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);

            Assert.AreEqual(_result.Success, true);

        }
    }
}
