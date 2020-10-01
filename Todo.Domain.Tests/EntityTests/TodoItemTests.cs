using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _todo = new TodoItem("Nova Tarefa", DateTime.Now, "Willian");

        [TestMethod]
        public void Given_a_new_todo_it_must_be_undone()
        {
            Assert.AreEqual(_todo.Done, false);
        }
    }
}

