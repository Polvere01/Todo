using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands.Contracts
{
    public class MakeTodoAsDoneCommand : Notifiable, ICommand
    {

        public MakeTodoAsDoneCommand()
        {
        }

        public MakeTodoAsDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(User, 6, "User", "Usuário inválido")

            );
        }
    }
}