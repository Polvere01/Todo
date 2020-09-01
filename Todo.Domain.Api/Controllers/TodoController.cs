using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repository;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        private readonly TodoHandler _todoHandler;
        private readonly ITodoRepository _todoRepository;

        public TodoController(TodoHandler todoHandler, ITodoRepository todoRepository)
        {
            _todoHandler = todoHandler;
            _todoRepository = todoRepository;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _todoRepository.GetAll("ygorpolvere");
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command)
        {
            command.User = "ygorpolvere";
            return (GenericCommandResult)_todoHandler.Handle(command);
        }
    }
}