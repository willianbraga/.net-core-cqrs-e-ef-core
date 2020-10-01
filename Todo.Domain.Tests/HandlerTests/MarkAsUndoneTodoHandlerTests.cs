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
        private GenericCommandResult _result = new GenericCommandResult();
        [TestMethod]
        public void Given_a_invalid_command_must_stop_running()
        {
            _result = (GenericCommandResult)_handle.Handle(new MarkTodoAsUndoneCommand());
            Assert.AreEqual(_result.Success, false);
        }
        [TestMethod]
        public void Given_a_valid_command_must_create_todo()
        {
            _result = (GenericCommandResult)_handle.Handle(_invalidTodo);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
