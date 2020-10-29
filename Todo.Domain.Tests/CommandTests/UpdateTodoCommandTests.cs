using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class UpdateTodoCommandTests
    {
        private readonly UpdateTodoCommand _invalidCommand = new UpdateTodoCommand(Guid.NewGuid(), "", "");
        private readonly UpdateTodoCommand _validCommand = new UpdateTodoCommand(Guid.NewGuid(), "Tarefa criada com sucesso", "Wilian Braga");
        public UpdateTodoCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Given_an_invalid_command()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }
        [TestMethod]
        public void Given_a_valid_command()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
