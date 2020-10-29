using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class MarkTodoAsDoneCommandTests
    {
        private readonly MarkTodoAsDoneCommand _invalidCommand = new MarkTodoAsDoneCommand(Guid.NewGuid(), "");
        private readonly MarkTodoAsDoneCommand _validCommand = new MarkTodoAsDoneCommand(Guid.NewGuid(), "Wilian Braga");
        public MarkTodoAsDoneCommandTests()
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
