using dotnetTodoRefactor.Models;
using dotnetTodoRefactor.Data;
using Npgsql;



namespace dotnetTodoRefactor.Services
{
    public class DeleteTodoService : IDeleteTodoService
    {
        public TodoModel DeleteToDo(int id)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (var connection = dbConnection.GetConnection())
            {
                var deletedToDo = new TodoModel();
                using var command = new NpgsqlCommand("DELETE FROM todos_info  WHERE id = @p1 RETURNING *", connection)
                {
                    Parameters =
                {
                    new NpgsqlParameter("p1", id)
                }
                };

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    deletedToDo = new TodoModel
                    {
                        Id = reader.GetInt32(0),
                        Text = reader.GetString(1),
                        IsComplete = reader.GetBoolean(2),
                        CreatedAt = reader.GetDateTime(3)
                    };
                }
                return deletedToDo;
            };

        }
    }
}
