using dotnetTodoRefactor.Data;
using dotnetTodoRefactor.Models;
using Npgsql;

namespace dotnetTodoRefactor.Services
{
    public class UpdateToDoService : IUpdateTodoService
    {
        public TodoModel UpdateToDo(int id, bool isComplete)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (var connection = dbConnection.GetConnection())
            {
                var updatedTodo = new TodoModel();
                using var command = new NpgsqlCommand("UPDATE todos_info SET is_complete = @p1 WHERE id = @p2 RETURNING *", connection)
                {
                    Parameters =
                {
                    new NpgsqlParameter("p1", isComplete),
                    new NpgsqlParameter("p2", id)
                }
                };

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    updatedTodo = new TodoModel
                    {
                        Id = reader.GetInt32(0),
                        Text = reader.GetString(1),
                        IsComplete = isComplete,
                        CreatedAt = reader.GetDateTime(3)
                    };
                }
                return updatedTodo;
            };

        }
    }
}
