using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repository;

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

