using System;
namespace dotnetTodoRefactor.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
