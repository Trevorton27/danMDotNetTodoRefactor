using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using dotnetTodoRefactor.Models;
using dotnetTodoRefactor.Services;

namespace dotNetTodoReview.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {

        private readonly IPostTodoService _postTodoService;
        private readonly IGetTodoService _getTodoService;
        private readonly IUpdateTodoService _updateTodoService;
        private readonly IDeleteTodoService _deleteTodoService;


        public TodosController(IDeleteTodoService deleteTodoService, IGetTodoService getTodoService, IUpdateTodoService updateTodoService, IPostTodoService postTodoService)

        {
            _deleteTodoService = deleteTodoService;
            _getTodoService = getTodoService;
            _postTodoService = postTodoService;
            _updateTodoService = updateTodoService;

        }

        // GET: api/<ToDosController>
        [HttpGet]
        public List<TodoModel> Get()
        {

            var todos = _getTodoService.GetTodos();

            return todos;

        }

        // GET api/<ToDosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ToDosController>
        [HttpPost]
        public TodoModel Post([FromBody] TodoModel todo)
        {

            var text = todo.Text;

            return _postTodoService.PostToDo(text);
        }

        // PUT api/<ToDosController>/5
        [HttpPut("{id}")]
        public TodoModel Put(int id, [FromBody] TodoModel todo)
        {

            int todoId = id;
            var isComplete = todo.IsComplete;

            return _updateTodoService.UpdateToDo(todoId, isComplete);
        }

        // DELETE api/<ToDosController>/5
        [HttpDelete("{id}")]
        public TodoModel Delete(int id)
        {

            int todoId = id;

            return _deleteTodoService.DeleteToDo(todoId);
        }
    }
}
