using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private readonly List<TodoItem> _items;
        public TodoQueryTests()
        {
            _items = new List<TodoItem>
            {
                new TodoItem("Tarefa 1", DateTime.Now, "Usuario 1"),
                new TodoItem("Tarefa 2", DateTime.Now, "willian"),
                new TodoItem("Tarefa 3", DateTime.Now, "Usuario 1"),
                new TodoItem("Tarefa 4", DateTime.Now, "Usuario 1"),
                new TodoItem("Tarefa 5", DateTime.Now, "willian")
            };
        }
        [TestMethod]
        public void Should_return_only_todo_of_willian()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("willian"));
            Assert.AreEqual(2, result.Count());
        }
        [TestMethod]
        public void Should_return_only_todo_done_of_willian()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("willian"));
            Assert.AreEqual(0, result.Count());
        }
        [TestMethod]
        public void Should_return_only_todo_undone_of_willian()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("willian"));
            Assert.AreEqual(2, result.Count());
        }
        [TestMethod]
        public void Should_return_only_todo_of_a_day_undone()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("willian", DateTime.Now, false));
            Assert.AreEqual(2, result.Count());
        }
        [TestMethod]
        public void Should_return_only_todo_of_a_day_done()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("willian", DateTime.Now, true));
            Assert.AreEqual(0, result.Count());
        }
        [TestMethod]
        public void Should_return_only_todo_an_id()
        {

        }
    }
}