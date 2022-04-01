using System;
using Npgsql;
using DotNetEnv;
namespace dotnetTodoRefactor.Data
{
    public class DatabaseConnection
    {
        public NpgsqlConnection GetConnection()
        {
             Env.TraversePath().Load();
            string connString = Environment.GetEnvironmentVariable("DEVELOPMENT_CONNECTION_STRING");
            //string connString = Environment.GetEnvironmentVariable("PRODUCTION_CONNECTION_STRING");

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();
            return conn;
        }
    }
}
