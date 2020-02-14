using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class MarkTodoAsDoneCommandTests
    {
        private static readonly TodoItem _invalidTodoItem = new TodoItem("Teste Invalido", DateTime.Now, "");
        private static readonly TodoItem _validTodoItem = new TodoItem("Teste Valido", DateTime.Now, "Willian");
        private readonly MarkTodoAsDoneCommand _invalidDone = new MarkTodoAsDoneCommand(_invalidTodoItem.Id, _invalidTodoItem.User);
        private readonly MarkTodoAsDoneCommand _validDone = new MarkTodoAsDoneCommand(_validTodoItem.Id, _validTodoItem.User);


        public MarkTodoAsDoneCommandTests()
        {
            _invalidDone.Validate();
            _validDone.Validate();
        }

        [TestMethod]
        public void Given_a_invalid_command()
        {
            Assert.AreEqual(_invalidDone.Valid, false);
        }
        [TestMethod]
        public void Given_a_valid_command()
        {
            Assert.AreEqual(_validDone.Valid, true);
        }
    }
}
