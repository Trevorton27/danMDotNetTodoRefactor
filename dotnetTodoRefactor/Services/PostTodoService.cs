using dotnetTodoRefactor.Data;
using dotnetTodoRefactor.Models;
using Npgsql;

namespace dotnetTodoRefactor.Services
{
    public class PostToDoService : IPostTodoService
    {
        public TodoModel PostToDo(string text)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (var connection = dbConnection.GetConnection())
            {
                var newTodo = new TodoModel();
                using var command = new NpgsqlCommand("INSERT INTO todos_info (todo_text) VALUES (@p1) RETURNING *", connection)
                {
                    Parameters =
                {
                    new NpgsqlParameter("p1", text)
                }
                };

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    newTodo = new TodoModel
                    {
                        Id = reader.GetInt32(0),
                        Text = text,
                        IsComplete = reader.GetBoolean(2),
                        CreatedAt = reader.GetDateTime(3)
                    };
                }
                return newTodo;
            };

        }
    }
}
