using dotnetTodoRefactor.Models;

namespace dotnetTodoRefactor.Services
{
    public interface IUpdateTodoService
    {
        TodoModel UpdateToDo(int id, bool isComplete);
    }
}
