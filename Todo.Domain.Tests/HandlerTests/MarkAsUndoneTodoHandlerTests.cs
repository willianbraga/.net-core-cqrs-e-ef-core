using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class MarkAsUndoneTodoHandlerTests
    {
        private readonly MarkTodoAsUndoneCommand _invalidTodo = new MarkTodoAsUndoneCommand(new Guid(), "Willian");
        private readonly TodoHandler _handle = new TodoHandler(new FakeTodoRepository());
        private GenericCommandResult _validResult = new GenericCommandResult();
        private GenericCommandResult _invalidResult = new GenericCommandResult();

        public MarkAsUndoneTodoHandlerTests()
        {
            _invalidResult = (GenericCommandResult)_handle.Handle(new MarkTodoAsUndoneCommand());
            _validResult = (GenericCommandResult)_handle.Handle(_invalidTodo);
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
