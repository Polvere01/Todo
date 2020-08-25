using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MakeTodoAsUndoneCommand : Notifiable, ICommand
    {

        public MakeTodoAsUndoneCommand()
        {

        }

        public MakeTodoAsUndoneCommand(Guid id, string user)
        {
            this.Id = id;
            this.User = user;
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