using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class UpdateTodoCommandTests
    {
        private readonly TodoItem _invalidTodoItem = new TodoItem("", DateTime.Now, "");
        private readonly TodoItem _validTodoItem = new TodoItem("Teste Valido", DateTime.Now, "Willian");

        public UpdateTodoCommandTests()
        {
        }

        [TestMethod]
        public void Given_a_invalid_command()
        {
            UpdateTodoCommand _invalidUpdate = new UpdateTodoCommand(_invalidTodoItem.Id, _invalidTodoItem.Title, _invalidTodoItem.User);
            _invalidUpdate.Validate();
            Assert.AreEqual(_invalidUpdate.Valid, false);
        }
        [TestMethod]
        public void Given_a_valid_command()
        {
            UpdateTodoCommand _validUpdate = new UpdateTodoCommand(_validTodoItem.Id, _validTodoItem.Title, _validTodoItem.User);
            _validUpdate.Validate();
            Assert.AreEqual(_validUpdate.Valid, true);
        }
    }
}
