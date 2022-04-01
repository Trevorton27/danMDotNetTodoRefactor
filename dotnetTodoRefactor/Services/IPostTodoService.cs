using dotnetTodoRefactor.Models;

namespace dotnetTodoRefactor.Services
{
    public interface IPostTodoService
    {
        TodoModel PostToDo(string text);
    }
}
