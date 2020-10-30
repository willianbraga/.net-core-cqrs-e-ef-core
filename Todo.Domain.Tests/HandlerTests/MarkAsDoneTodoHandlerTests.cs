using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class MarkAsDoneTodoHandlerTests
    {
        private static readonly TodoItem _invalidTodoItem = new TodoItem("Teste Invalido", DateTime.Now, "");
        private static readonly TodoItem _validTodoItem = new TodoItem("Teste Valido", DateTime.Now, "Willian");
        private readonly MarkTodoAsDoneCommand _invalidCommand = new MarkTodoAsDoneCommand(_invalidTodoItem.Id, _invalidTodoItem.User);
        private readonly MarkTodoAsDoneCommand _validCommand = new MarkTodoAsDoneCommand(_validTodoItem.Id, _validTodoItem.User);
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
        private GenericCommandResult _validResult = new GenericCommandResult();
        private GenericCommandResult _invalidResult = new GenericCommandResult();

        public MarkAsDoneTodoHandlerTests()
        {
            _invalidResult = (GenericCommandResult)_handler.Handle(_invalidCommand);
            _validResult = (GenericCommandResult)_handler.Handle(_validCommand);

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
