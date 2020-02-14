using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class MarkTodoAsUndoneCommandTests
    {
        private readonly TodoItem _invalidTodoItem = new TodoItem("Teste Invalido", DateTime.Now, "");
        private readonly TodoItem _validTodoItem = new TodoItem("Teste Valido", DateTime.Now, "Willian");

        public MarkTodoAsUndoneCommandTests()
        {
        }

        [TestMethod]
        public void Given_a_invalid_command()
        {
            MarkTodoAsUndoneCommand _invalidDone = new MarkTodoAsUndoneCommand(_invalidTodoItem.Id, _invalidTodoItem.User);
            _invalidDone.Validate();
            Assert.AreEqual(_invalidDone.Valid, false);
        }
        [TestMethod]
        public void Given_a_valid_command()
        {
            MarkTodoAsUndoneCommand _validDone = new MarkTodoAsUndoneCommand(_validTodoItem.Id, _validTodoItem.User);
            _validDone.Validate();
            Assert.AreEqual(_validDone.Valid, true);
        }
    }
}
