using System;

namespace Todo.Domain.Entities
{
    public class TodoItem : Entity
    {
        public TodoItem(string title, bool done, DateTime date, string user)
        {
            this.Title = title;
            this.Done = done;
            this.Date = date;
            this.User = user;

        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }

        public void MarkAsDone()
        {
            Done = true;
        }

        public void MarkAsUnDone()
        {
            Done = false;
        }


        public void Update(string title)
        {
            Title = title;
        }
    }
}