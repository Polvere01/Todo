using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repository;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MakeTodoAsDoneCommand>,
        IHandler<MakeTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // Fail fast Validation 
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que a sua tarefa está errada",
                    command.Notifications
                );

            //Gera o TodoItem
            TodoItem todoItem = new TodoItem(command.Title, command.Date, command.User);

            //Salva no banco
            _repository.Create(todoItem);

            //Retorna o resultado
            return new GenericCommandResult(true, "Tarefa Salva", todoItem);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Fail fast Validation 
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que a sua tarefa está errada",
                    command.Notifications
                );

            //Recuperar TodoItem
            TodoItem todoItem = _repository.GetById(command.Id, command.User);

            //Altera titulo
            todoItem.UpdateTitle(command.Title);

            //Salva no banco
            _repository.Update(todoItem);

            return new GenericCommandResult(true, "Tarefa atualizada", todoItem);
        }

        public ICommandResult Handle(MakeTodoAsDoneCommand command)
        {
            // Fail fast Validation 
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que a sua tarefa está errada",
                    command.Notifications
                );

            //Recuperar TodoItem
            TodoItem todoItem = _repository.GetById(command.Id, command.User);

            todoItem.MarkAsUnDone();

            return new GenericCommandResult(true, "Tarefa atualizada", todoItem);
        }

        public ICommandResult Handle(MakeTodoAsUndoneCommand command)
        {
            // Fail fast Validation 
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que a sua tarefa está errada",
                    command.Notifications
                );

            //Recuperar TodoItem
            TodoItem todoItem = _repository.GetById(command.Id, command.User);

            todoItem.MarkAsUnDone();

            return new GenericCommandResult(true, "Tarefa atualizada", todoItem);
        }
    }
}