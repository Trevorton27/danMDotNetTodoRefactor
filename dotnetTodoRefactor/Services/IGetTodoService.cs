using dotnetTodoRefactor.Models;
using System.Collections.Generic;

namespace dotnetTodoRefactor.Services
{
    public interface IGetTodoService
    {
        List<TodoModel> GetTodos();
    }
}
