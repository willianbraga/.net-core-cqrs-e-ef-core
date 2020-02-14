using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repository;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class UpdateTodoHandlerTests
    {
        [TestMethod]
        public void Given_a_invalid_command_must_stop_running()
        {
            UpdateTodoCommand _invalidUpdate = new UpdateTodoCommand(new Guid(),"","");
            TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
            var _result = (GenericCommandResult)_handler.Handle(_invalidUpdate);
            Assert.AreEqual(_result.Success, false);
        }
        [TestMethod]
        public void Given_a_valid_command_must_create_todo()
        {
            UpdateTodoCommand _invalidUpdate = new UpdateTodoCommand(new Guid(),"Teste valido","Willian");
            TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
            var _result = (GenericCommandResult)_handler.Handle(_invalidUpdate);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
