using System;
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
            return x => x.User == user;
        }
        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return x => x.User == user && x.Done == true;
        }
        public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
        {
            return x => x.User == user && x.Done == false;
        }
        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            var dateTime = date.ToString("dd/MM/yyy");
            return x =>
                x.User == user &&
                x.Date.ToString("dd/MM/yyy") == dateTime &&
                x.Done == done;
        }
        public static Expression<Func<TodoItem, bool>> GetById(string user, Guid id)
        {
            return x => x.User == user && x.Id == id;
        }
    }
}