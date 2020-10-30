using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class UpdateTodoHandlerTests
    {
        private readonly UpdateTodoCommand _invalidUpdate = new UpdateTodoCommand(new Guid(), "", "");
        private readonly UpdateTodoCommand _validTodo = new UpdateTodoCommand(new Guid(), "Tarefa valida", "Willian");

        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
        private GenericCommandResult _validResult = new GenericCommandResult();
        private GenericCommandResult _invalidResult = new GenericCommandResult();
        public UpdateTodoHandlerTests()
        {
            _invalidResult = (GenericCommandResult)_handler.Handle(_invalidUpdate);
            _validResult = (GenericCommandResult)_handler.Handle(_validTodo);


        }
        [TestMethod]
        public void Given_a_invalid_command_must_stop_running()
        {
            Assert.AreEqual(_invalidResult.Success, false);
        }
        [TestMethod]
        public void Given_a_valid_command_must_create_todo()
        {
            Assert.AreEqual(_validResult.Success, true);
        }
    }
}
