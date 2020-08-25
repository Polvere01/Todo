using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace Todo.Domain.Commands.Contracts
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {


        public UpdateTodoCommand()
        {

        }

        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string User { get; private set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor está tarefa")
                    .HasMinLen(User, 6, "User", "Usuário inválido")
            );
        }
    }
}