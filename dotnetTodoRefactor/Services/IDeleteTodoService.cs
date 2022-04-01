using dotnetTodoRefactor.Models;
using System;
using System.Collections.Generic;
namespace dotnetTodoRefactor.Services
{
    public interface IDeleteTodoService
    {
        TodoModel DeleteToDo(int id);
    }
}