using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Repository
{
    public interface ITodoRepository
    {
        void Create(TodoItem todoItem);
        void Update(TodoItem todoItem);

        TodoItem GetById(Guid guid, String user);
    }
}