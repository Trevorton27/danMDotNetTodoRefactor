using dotnetTodoRefactor.Data;
using dotnetTodoRefactor.Models;
using Npgsql;
using System.Collections.Generic;

namespace dotnetTodoRefactor.Services
{
    public class GetToDoService : IGetTodoService
    {

        public List<TodoModel> GetTodos()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (var connection = dbConnection.GetConnection())
            {
                var todos = new List<TodoModel>();
                using NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM todos_info ORDER BY id", connection);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TodoModel todo = new TodoModel
                    {
                        Id = reader.GetInt32(0),
                        Text = reader.GetString(1),
                        IsComplete = reader.GetBoolean(2),
                        CreatedAt = reader.GetDateTime(3)
                    };
                    todos.Add(todo);
                }

                return todos;
            };

        }
    }
}
